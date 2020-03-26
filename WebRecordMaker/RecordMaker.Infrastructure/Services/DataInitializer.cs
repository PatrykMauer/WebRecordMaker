using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Fluent;
using RecordMaker.Core.Domain;

namespace RecordMaker.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ITableService _tableService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DataInitializer(IUserService userService,
            ITableService tableService)
        {
            _userService = userService;
            _tableService = tableService;
        }
        
        public async Task SeedAsync()
        {
           Logger.Trace("Initializing data...");
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
           Logger.Trace("Data has been initialized.");
        }
    }
}