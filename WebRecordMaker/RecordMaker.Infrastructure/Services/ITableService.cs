using System;
using System.Collections.Generic;
using RecordMaker.Core.Domain;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface ITableService
    {
        TableDto Get(Guid id);
        IEnumerable<TableDto> GetAll();
        void Add(string size, List<Cell> cells);
    }
}