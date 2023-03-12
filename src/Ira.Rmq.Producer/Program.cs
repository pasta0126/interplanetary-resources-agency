using System.Text;
using Ira.Models.Dtos.Rmq;
using Ira.Models.Entities;
using Ira.Rmq.Producer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Serilog;

var _sleep = 60000; // millis
var _queueName = "Ira.Emails";
var _config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true).Build();

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

while (true)
{
    var dal = new Dal(_config);
    var notifications = dal.GetAllNotifications();

    notifications.ForEach((notification) =>
    {
        SendToRmq(notification, _queueName);
    });

    Thread.Sleep(_sleep);
}

void SendToRmq(Notification notification, string queueName)
{
    var notificationRmq = new NotificationRmq()
    {
        Id = notification.Id,
        Email = notification.Email,
        Message = notification.Message,
        Subject = notification.Subject,
    };

    var json = JsonConvert.SerializeObject(notificationRmq);
    var body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: string.Empty,
                         routingKey: queueName,
                         basicProperties: null,
                         body: body);
}
