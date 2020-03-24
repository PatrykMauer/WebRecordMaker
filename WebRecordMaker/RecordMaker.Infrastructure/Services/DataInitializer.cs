using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RecordMaker.Core.Domain;

namespace RecordMaker.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger<DataInitializer> _logger;
        private readonly ITableService _tableService;

        public DataInitializer(IUserService userService,
            ILogger<DataInitializer> logger,
            ITableService tableService)
        {
            _userService = userService;
            _logger = logger;
            _tableService = tableService;
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
               tasks.Add(_tableService.AddAsync(userId, "10,x10"));
           }

           await Task.WhenAll(tasks);
           _logger.LogInformation("Data has been initialized.");
        }
    }
}