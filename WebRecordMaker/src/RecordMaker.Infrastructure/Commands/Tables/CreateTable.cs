using System.Collections.Generic;
using RecordMaker.Core.Domain;
using RecordMaker.Infrastructure.Commands.Users;

namespace RecordMaker.Infrastructure.Commands.Tables
{
    public class CreateTable : AuthenticatedCommandBase
    {
        public string Size { get; set; }

        public List<Cell> Cells { get; set; }
            = new List<Cell>();
    }
}