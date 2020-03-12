using System;
using System.Collections.Generic;
using RecordMaker.Core.Domain;

namespace RecordMaker.Core.Repositories
{
    public interface ITableRepository
    {
        Table Get(Guid id);
        IEnumerable<Table> GetAll();
        void Add(Table table);
        void Update(Table table);
        void Remove(Guid id);
    }
}