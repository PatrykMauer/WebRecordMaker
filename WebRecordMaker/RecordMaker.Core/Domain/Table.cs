using System;
using System.Collections.Generic;

namespace RecordMaker.Core.Domain
{
    public class Table
    {
        public Guid Id { get; protected set; }
        public string Size { get; protected set; }
        public IEnumerable<Cell> Cells { get; protected set; }

        protected Table()
        {
            
        }
        public Table( string size)
        {
            Id = Guid.NewGuid();
            Size = size;
        }

        public void AddCell( int rowNumber, char columnLetter, string text)
        {
            var cell=new Cell(rowNumber,columnLetter,text);
            //????Cells=
        }
    }
}