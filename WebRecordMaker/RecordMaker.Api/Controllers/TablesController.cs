using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Cells;
using RecordMaker.Infrastructure.Commands.Tables;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Services;
namespace RecordMaker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TablesController : ApiControllerBase
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService,
            ICommandDispatcher commandDispatcher):base(commandDispatcher)
        {
            _tableService = tableService;
        }    

        [Authorize(Policy = "admin")]
        [HttpGet("{id}")]
        public async Task<TableDto> Get(Guid id)
            => await _tableService.GetAsync(id);

        [Authorize(Policy = "admin")]
        [Route("all")]
        [HttpGet]
        public async Task<IEnumerable<TableDto>> GetAll()
            => await _tableService.GetAllAsync();
        
        [Authorize(Policy = "admin")]
        [HttpPost("")]
        public async Task Post([FromBody] CreateTable command)
        {
            await DispatchAsync(command);
        }
        
        [Authorize(Policy = "referee")]
        [HttpPost("cell")]
        public async Task Post([FromBody] CreateCell command)
        {
            await DispatchAsync(command);
        }
    }
}
