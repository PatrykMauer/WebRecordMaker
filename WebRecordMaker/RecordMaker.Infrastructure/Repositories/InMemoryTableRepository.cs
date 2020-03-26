using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;

namespace RecordMaker.Infrastructure.Repositories
{
    public class InMemoryTableRepository:ITableRepository
    {

        private static ISet<Table> _tables = new HashSet<Table>();
        
        public async Task<Table> GetAsync(Guid id)
            => await Task.FromResult( _tables.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Table>> GetAllAsync()
            => await Task.FromResult(_tables);

        public async Task AddAsync(Table table)
        {
            await Task.FromResult(_tables.Add(table));
        }

        public async Task UpdateAsync(Table table)
        {
           var updatedTable =_tables.SingleOrDefault(x=>x.Id==table.Id);
           updatedTable?.SetCells(table.Cells);
           updatedTable?.SetSize(table.Size);
           await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        => await Task.FromResult(_tables.Remove(_tables.Single(x => x.Id == id)));
        
    }
}