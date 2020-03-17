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

        private static ISet<Table> _tables=new HashSet<Table>()
        {
            new Table( "10x10"),
            new Table("11x11")
        };

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
           await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        => await Task.FromResult(_tables.Remove(_tables.Single(x => x.Id == id)));
        
    }
}