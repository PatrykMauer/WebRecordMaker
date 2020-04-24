using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.Exceptions;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Services;
using Xunit;
using ErrorCodes = RecordMaker.Infrastructure.Exceptions.ErrorCodes;

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
            await tableService.AddAsync(Guid.NewGuid(),"10X10");
            
            _tableRepositoryMock.Verify(x=>x.AddAsync(It.IsAny<Table>()),Times.Once);
        }
        
        [Fact]
        public async Task invoking_add_cell_async_with_not_existing_tableId_should_throw_service_exception_not_found()
        {
            var tableService=new TableService(_tableRepositoryMock.Object, _mapperMock.Object);
            
             tableService.Invoking(x=>x.AddCellAsync(Guid.NewGuid(),Guid.NewGuid(),
                5,'z',"10X10"))
                 .Should().Throw<ServiceException>().Which.Code.Should().Be(ErrorCodes.TableNotFound);
             
             await Task.CompletedTask;
        }
        
        [Fact]
        public async Task invoking_add_cell_async_should_invoke_update_async_on_repository()
        {
            _tableRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Table(Guid.NewGuid(), "10x10"));
            var tableService=new TableService(_tableRepositoryMock.Object, _mapperMock.Object);
            
            await tableService.AddCellAsync(Guid.NewGuid(),Guid.NewGuid(),
                5,'z',"10X10");
            
            
            _tableRepositoryMock.Verify(x=>x.UpdateAsync(It.IsAny<Table>()),Times.Once);
        }
    }
}