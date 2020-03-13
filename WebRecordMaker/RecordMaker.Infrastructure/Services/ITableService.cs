using System;
using RecordMaker.Core.Domain;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface ITableService
    {
        TableDto Get(Guid id);
        void Add(string size);
    }
}