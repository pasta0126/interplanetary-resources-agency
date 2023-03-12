using Ira.Models.Config;
using Ira.Models.Dtos.Rmq;
using Ira.Rmq.Consumer;
using Ira.Services.Interfaces;
using Ira.Services.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;

var _queueName = "Ira.Emails";
var _config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true).Build();

var emailConfiguration = new EmailConfiguration();

_config.Bind("EmailConfiguration", emailConfiguration);

var serviceCollection = new ServiceCollection()
    .AddLogging(builder => builder
    .AddSerilog(
        new LoggerConfiguration()
        .ReadFrom.Configuration(_config)
            .CreateLogger()))
    .BuildServiceProvider();

var logger = serviceCollection.GetRequiredService<ILogger<Program>>();

var factory = new ConnectionFactory { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: _queueName,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var dal = new Dal(_config);

    var body = ea.Body.ToArray();
    var json = Encoding.UTF8.GetString(body);
    var NotificationRmq = JsonConvert.DeserializeObject<NotificationRmq>(json);
    var id = NotificationRmq.Id;
    var to = NotificationRmq.Email;

    logger.LogInformation("Received Notification {id} from RMQ", id);

    var message = new Message(
        to: new List<string>() { NotificationRmq.Email },
        subject: NotificationRmq.Subject,
        content: NotificationRmq.Message);

    var sendNotification = new SendNotification(emailConfiguration, logger);

    sendNotification.SendEmail(message);
    dal.UpdateNotification(NotificationRmq.Id);

    logger.LogInformation("Notification {id} sent successfully to {to}", id, to);
};

channel.BasicConsume(queue: _queueName,
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();
