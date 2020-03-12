namespace RecordMaker.Core.Domain
{
    public class Cell
    {
        public int RowNumber { get; protected set; }
        public int ColumnNumber { get; protected set; }
        public string Text { get;protected set; }
    }
}