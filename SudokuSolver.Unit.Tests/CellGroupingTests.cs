using System.Linq;
using NUnit.Framework;

namespace SudokuSolver.Unit.Tests
{
	class CellGroupingTests
	{
		private const int RowIndex = 0;
		private Grid _grid;

		[SetUp]
		public void SetUp()
		{
			_grid = new Grid();
			for (int colIndex = 0; colIndex < 8; colIndex++)
			{
				_grid.PutValue(RowIndex, colIndex, colIndex + 1);
			}
		}

		[Test]
		public void Should_check_whether_unsolved_cell_group_is_unsolved()
		{
			var row = _grid.GetRow(RowIndex);
			Assert.That(row.IsSolved(), Is.False);
		}

		[Test]
		public void Should_return_unsolved_cells()
		{
			var row = _grid.GetRow(RowIndex);
			Assert.That(row.SolvedCells().Count(), Is.EqualTo(8));
			Assert.That(row.UnsolvedCells().Count(), Is.EqualTo(1));
		}

		[Test]
		public void Should_check_whether_solved_cell_group_is_solved()
		{
			_grid.PutValue(RowIndex, 8, 9);
			var row = _grid.GetRow(RowIndex);
			Assert.That(row.IsSolved(), Is.True);
		}
	}
}