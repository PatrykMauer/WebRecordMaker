﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RecordMaker.Core.Domain
{
    public class Table
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Size { get; protected set; }

        public List<Cell> Cells { get; protected set; }
            =new List<Cell>();
        
        public DateTime UpdatedAt { get; protected set; }
           

        protected Table()
        {
        }
        public Table( Guid userId, string size)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Size = size;
        }

        public void AddCell(Guid userId, int rowNumber, char columnLetter, string text)
        {
            var cell=new Cell(userId,rowNumber,columnLetter,text);
            if (Cells.Any(x => x.RowNumber == rowNumber && x.ColumnLetter == columnLetter))
            {
                Cells.RemoveAll(x => x.RowNumber == rowNumber && x.ColumnLetter == columnLetter);
            }
            Cells.Add(cell);
            UpdatedAt=DateTime.UtcNow;
        }

        public void AddAllCells(List<Cell> cells)
        {
            Cells = cells;
            UpdatedAt=DateTime.UtcNow;
        }
    }
}