using NUnit.Framework;

namespace SudokuSolver.Unit.Tests
{
	[TestFixture]
	class MissingValueFinderTests
	{
		[Test]
		public void Should_set_cell_value_to_missing_value_in_row()
		{
			var grid = new Grid();
			const int rowIndex = 0;
			for (int colIndex = 1; colIndex < 9; colIndex++)
			{
				grid.PutValue(rowIndex, colIndex, colIndex);
			}
			var solver = new Solver(grid);
			solver.SolveRow(rowIndex);
			Assert.That(grid.GetCell(rowIndex, 0).Value, Is.EqualTo(9));
		}

		[Test]
		public void Should_set_cell_value_to_missing_value_in_column()
		{
			var grid = new Grid();
			const int colIndex = 0;
			for (int rowIndex = 1; rowIndex < 9; rowIndex++)
			{
				grid.PutValue(rowIndex, colIndex, rowIndex);
			}
			var solver = new Solver(grid);
			solver.SolveCol(colIndex);
			Assert.That(grid.GetCell(0, colIndex).Value, Is.EqualTo(9));
		}

		[Test]
		public void Should_set_cell_value_to_missing_value_in_box()
		{
			var grid = new Grid();
			for (int i = 1; i < 9; i++)
			{
				grid.PutValue(i/3, i%3, i);
			}
			var solver = new Solver(grid);
			solver.SolveBox(0);
			Assert.That(grid.GetCell(0, 0).Value, Is.EqualTo(9));
		}
	}
}
