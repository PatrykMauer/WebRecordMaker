using System;

namespace RecordMaker.Core.Domain
{
    public class Cell //ValueObject ->immutable
    {
        public Guid UserId { get; protected set; }
        public int RowNumber { get; protected set; }
        public char ColumnLetter { get; protected set; }
        public string Text { get; protected set; }
        protected Cell()
        {
        }
        public Cell(Guid userId, int rowNumber,char columnLetter, string text)
        { 
            SetUserId(userId);
            SetRowNumber(rowNumber);
            SetColumnLetter(columnLetter); 
            SetText(text);
        }

        private void SetUserId(Guid userId)
        {
            UserId = userId;
        }
        
        private void SetRowNumber(int rowNumber)
        {
            RowNumber = rowNumber;
        }

        private void SetColumnLetter(char columnLetter)
        {
            ColumnLetter = columnLetter;
        }

        private void SetText(string text)
        {
            Text = text;
        }
    }
}