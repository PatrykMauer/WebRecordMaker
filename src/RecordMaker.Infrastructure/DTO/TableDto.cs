using System;
using System.Collections.Generic;
using RecordMaker.Core.Domain;

namespace RecordMaker.Infrastructure.DTO
{
    public class TableDto
    {
        public Guid Id { get;  set; }
        public string Size { get;  set; }
        public IEnumerable<Cell> Cells { get;  set; }
        public DateTime UpdatedAt { get; set; }
    }
}