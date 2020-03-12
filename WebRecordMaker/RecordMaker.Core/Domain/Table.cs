using System;
using System.Collections.Generic;

namespace RecordMaker.Core.Domain
{
    public class Table
    {
        public Guid Id { get; protected set; }
        public string Size { get; protected set; }
        public IEnumerable<Cell> Cells { get; protected set; }
    }
}