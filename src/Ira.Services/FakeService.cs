using Ira.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Services
{
    public class FakeService: IFakeService
    {
        private readonly ILogger<FakeService> _logger;

        public FakeService(
            ILogger<FakeService> logger)
        {
            _logger = logger;
        }

    }
}
