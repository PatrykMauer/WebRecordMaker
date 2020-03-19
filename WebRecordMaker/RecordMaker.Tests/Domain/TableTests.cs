using System.Threading.Tasks;
using FluentAssertions;
using RecordMaker.Core.Domain;
using Xunit;

namespace RecordMaker.Tests.Domain
{
    public class TableTests
    {
        [Fact]
        public void add_cells_should_save_given_cells()
        {
            var table=new Table("10x10");
            table.AddCell(5,'A',"test");
            var cell = new Cell(5, 'A', "test");
            
            table.Cells.Should().ContainEquivalentOf(cell);
        }
        
        [Fact]
        public void add_cells_should_override_existing_cell_when_given_cell_has_same_coordinates()
        {
            var table=new Table("10x10");
            table.AddCell(5,'A',"test");
            table.AddCell(5,'A',"test2");
            var cell2 = new Cell(5, 'A', "test2");
            
            table.Cells.Should().ContainEquivalentOf(cell2);
        }
    }
}