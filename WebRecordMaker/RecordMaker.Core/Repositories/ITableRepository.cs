using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecordMaker.Core.Domain;

namespace RecordMaker.Core.Repositories
{
    public interface ITableRepository
    {
        Task<Table> GetAsync(Guid id);
        Task<IEnumerable<Table>> GetAllAsync();
        Task AddAsync(Table table);
        Task UpdateAsync(Table table);
        Task RemoveAsync(Guid id);
    }
}