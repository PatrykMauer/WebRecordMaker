using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecordMaker.Core.Domain;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface ITableService : IService

    {
    Task<TableDto> GetAsync(Guid id);
    Task<IEnumerable<TableDto>> GetAllAsync();
    Task AddAsync(Guid userId, string size);
    Task AddCellAsync(Guid tableId, Guid userId, int rowNumber, char columnLetter, string text);
    }
}