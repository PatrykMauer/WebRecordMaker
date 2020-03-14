using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands.Tables;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Api.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet("{id}")]
        public TableDto Get(Guid id)
            => _tableService.Get(id);

        [Microsoft.AspNetCore.Mvc.Route("all")]
        [HttpGet]
        public IEnumerable<TableDto> GetAll()
            => _tableService.GetAll();
        
        [HttpPost("")]
        public void Post([FromBody] CreateTable request)
        {
            _tableService.Add(request.Size,request.Cells);
        }
    }
}
