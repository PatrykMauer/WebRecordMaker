using System;
using System.Collections.Generic;
using System.Linq;
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
            var users = await _userService.GetAllAsync();
            if (users.Any())
            {
                return;
            }
            
           Logger.Trace("Initializing data...");
           for (var i = 1; i <=10; i++)
           {
               var userId = Guid.NewGuid();
               var username = $"user{i}";
              await _userService.RegisterAsync(userId, $"{username}@test.com",
                  username, "Str@ngPassword1", "referee");
           }
           for (var i = 1; i <=3; i++)
           {
               var userId = Guid.NewGuid();
               var username = $"observer{i}";
               await _userService.RegisterAsync(userId, $"{username}@test.com",
                   username, "secret", "admin");
               await _tableService.AddAsync(userId, "10,x10");
           }

           Logger.Trace("Data has been initialized.");
        }
    }
}