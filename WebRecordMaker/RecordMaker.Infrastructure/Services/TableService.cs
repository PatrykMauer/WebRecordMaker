﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<TableDto> GetAsync(Guid id)
        {
            var table = await _tableRepository.GetAsync(id);
            return _mapper.Map<Table, TableDto>(table);
        }

        public async Task<IEnumerable<TableDto>> GetAllAsync()
        {
            var tables =await  _tableRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Table>, IEnumerable<TableDto>>(tables);
        }

        public async Task AddAsync(Guid userId, string size)
        {
           var table = new Table(userId,size);
           await _tableRepository.AddAsync(table);
        }

        public async Task AddCellAsync(Guid tableId, Guid userId, int rowNumber, char columnLetter, string text)
        {
            var table = await _tableRepository.GetAsync(tableId);
            if (table == null)
            {
                throw new Exception($"Table with id: {tableId} does not exist. First create a table");
            }
            table.AddCell(userId,rowNumber,columnLetter,text);
            
            await _tableRepository.UpdateAsync(table);
        }
    }
}