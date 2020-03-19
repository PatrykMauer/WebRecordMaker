using System;
using System.Collections.Generic;
using System.Linq;

namespace RecordMaker.Core.Domain
{
    public class Table
    {
        public Guid Id { get; protected set; }
        public string Size { get; protected set; }

        public List<Cell> Cells { get; protected set; }
            =new List<Cell>();
           

        protected Table()
        {
        }
        public Table( string size)
        {
            Id = Guid.NewGuid();
            Size = size;
            Cells=new List<Cell>();
        }

        public void AddCell( int rowNumber, char columnLetter, string text)
        {
            var cell=new Cell(rowNumber,columnLetter,text);
            if (Cells.Any(x => x.RowNumber == rowNumber && x.ColumnLetter == columnLetter))
            {
                Cells.RemoveAll(x => x.RowNumber == rowNumber && x.ColumnLetter == columnLetter);
            }
            Cells.Add(cell);
        }

        public void AddAllCells(List<Cell> cells)
        {
            Cells = cells;
        }
    }
}