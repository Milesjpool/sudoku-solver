using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SudokuSolver.Unit.Tests
{
	[TestFixture]
	public class ValueSetupTests
	{
		[Test]
		public void Should_add_prefilled_cell_value_to_grid()
		{
			var grid = new Grid();
			const int value = 4;
			const int row = 1;
			const int col = 1;
			grid.PutValue(row, col, value);
			var cell = grid.GetCell(row, col);
			Assert.That(cell.Value, Is.EqualTo(value));
		}
	}
}