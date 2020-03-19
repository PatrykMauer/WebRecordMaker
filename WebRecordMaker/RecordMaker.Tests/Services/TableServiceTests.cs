using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.Services;
using Xunit;

namespace RecordMaker.Tests.Services
{
    public class TableServiceTests
    {
        private readonly Mock<ITableRepository> _tableRepositoryMock = new Mock<ITableRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        
        [Fact]
        public async Task invoking_get_async_should_invoke_get_async_on_repository()
        {
            var tableService=new TableService(_tableRepositoryMock.Object, _mapperMock.Object);
            await tableService.GetAsync(Guid.NewGuid());
            
            _tableRepositoryMock.Verify(x=>x.GetAsync(It.IsAny<Guid>()),Times.Once);
        }
        
        [Fact]
        public async Task invoking_get_all_async_should_invoke_get_all_async_on_repository()
        {
            var tableService=new TableService(_tableRepositoryMock.Object, _mapperMock.Object);
            await tableService.GetAllAsync();
            
            _tableRepositoryMock.Verify(x=>x.GetAllAsync(),Times.Once);
        }
        
        [Fact]
        public async Task invoking_add_async_should_invoke_add_async_on_repository()
        {
            var tableService=new TableService(_tableRepositoryMock.Object, _mapperMock.Object);
            List<Cell> cells=new List<Cell>();
            await tableService.AddAsync("10X10",cells);
            
            _tableRepositoryMock.Verify(x=>x.AddAsync(It.IsAny<Table>()),Times.Once);
        }
    }
}