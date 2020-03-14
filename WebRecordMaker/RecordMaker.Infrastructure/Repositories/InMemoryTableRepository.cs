using System;
using System.Collections.Generic;
using System.Linq;
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

        public Table Get(Guid id)
            => _tables.SingleOrDefault(x => x.Id == id);

        public IEnumerable<Table> GetAll()
            => _tables;

        public void Add(Table table)
        {
            _tables.Add(table);
        }

        public void Update(Table table)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        => _tables.Remove(_tables.Single(x => x.Id == id));
        
    }
}