using System;

namespace RecordMaker.Infrastructure.DTO
{
    public class CellDto
    {
        public Guid TableId { get; set; }
        public int RowNumber { get; set; }
        public char ColumnLetter { get; set; }
        public string Text { get; set; }
    }
}