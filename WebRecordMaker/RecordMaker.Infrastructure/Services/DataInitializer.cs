using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace RecordMaker.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        
        public async Task SeedAsync()
        {
           _logger.LogInformation("Initializing data...");
           var tasks = new List<Task>();
           for (var i = 1; i <=10; i++)
           {
               var userId = Guid.NewGuid();
               var username = $"user{i}";
              tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com",
                  username, "secret", "Referee"));
           }
           for (var i = 1; i <=3; i++)
           {
               var userId = Guid.NewGuid();
               var username = $"observer{i}";
               tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com",
                   username, "secret", "Admin"));
           }

           await Task.WhenAll(tasks);
           _logger.LogInformation("Data has been initialized.");
        }
    }
}