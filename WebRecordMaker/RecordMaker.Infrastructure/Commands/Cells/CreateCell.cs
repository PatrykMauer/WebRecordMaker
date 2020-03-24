using System;

namespace RecordMaker.Infrastructure.Commands.Cells
{
    public class CreateCell : AuthenticatedCommandBase
    {
        public Guid TableId { get; set; }
        public int RowNumber { get;  set; }
        public char ColumnLetter { get; set; }
        public string Text { get; set; }
    }
}