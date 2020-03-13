using System;
using AutoMapper;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public class TableService:ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }
        
        public TableDto Get(Guid id)
        {
            var table = _tableRepository.Get(id);
            return _mapper.Map<Table, TableDto>(table);
        }

        public void Add(string size)
        {
           var table =new Table(size);
           _tableRepository.Add(table);
        }
    }
}