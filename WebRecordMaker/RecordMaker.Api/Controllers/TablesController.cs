using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Tables;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Api.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class TablesController : ApiControllerBase
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService,
            ICommandDispatcher commandDispatcher):base(commandDispatcher)
        {
            _tableService = tableService;
        }    

        [HttpGet("{id}")]
        public async Task<TableDto> Get(Guid id)
            => await _tableService.GetAsync(id);

        [Microsoft.AspNetCore.Mvc.Route("all")]
        [HttpGet]
        public async Task<IEnumerable<TableDto>> GetAll()
            => await _tableService.GetAllAsync();
        
        [HttpPost("")]
        public async Task Post([FromBody] CreateTable command)
        {
            await CommandDispatcher.DispatchAsync(command);
        }
    }
}
