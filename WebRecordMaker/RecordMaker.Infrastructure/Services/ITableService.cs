using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecordMaker.Core.Domain;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface ITableService
    {
        Task<TableDto> GetAsync(Guid id);
        Task<IEnumerable<TableDto>> GetAllAsync();
        Task AddAsync(string size, List<Cell> cells);
    }
}