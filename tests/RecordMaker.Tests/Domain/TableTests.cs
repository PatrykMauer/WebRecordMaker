﻿using System;
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
            var userId = Guid.NewGuid();
            var table=new Table(Guid.NewGuid(),"10x10");
            table.AddCell(userId,5,'A',"test");
            var cell = new Cell(userId,5, 'A', "test");
            
            table.Cells.Should().ContainEquivalentOf(cell);
        }
        
        [Fact]
        public void add_cells_should_override_existing_cell_when_given_cell_has_same_coordinates()
        {
            var userId = Guid.NewGuid();
            var table=new Table(Guid.NewGuid(), "10x10");
            table.AddCell(userId,5,'A',"test");
            table.AddCell(userId,5,'A',"test2");
            var cell2 = new Cell(userId,5, 'A', "test2");
            
            table.Cells.Should().ContainEquivalentOf(cell2);
        }
    }
}