using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SudokuSolver.Unit.Tests
{
	[TestFixture]
	public class GridSetupTests
	{
		private Grid _blankGrid;
		private const int GridSize = 9;

		[SetUp]
		public void Test_setup()
		{
			_blankGrid = new Grid();
		}

		[Test]
		public void Should_set_up_new_grid_of_81_cells()
		{
			var gridSize = _blankGrid.Count;
			Assert.That(gridSize, Is.EqualTo(GridSize*GridSize));
		}

		[Test]
		public void New_grid_should_contain_9_cells_in_each_row()
		{
			for (int rowIndex = 0; rowIndex < GridSize; rowIndex++)
			{
				var row = _blankGrid.GetRow(rowIndex);
				Assert.That(row.Count(), Is.EqualTo(GridSize));
			}
		}

		[Test]
		public void New_grid_should_contain_9_cells_in_each_column()
		{
			for (int colIndex = 0; colIndex < GridSize; colIndex++)
			{
				var col = _blankGrid.GetColumn(colIndex);
				Assert.That(col.Count(), Is.EqualTo(GridSize));
			}
		}

		[Test]
		public void New_grid_should_contain_9_cells_in_each_box()
		{
			for (int boxIndex = 0; boxIndex < GridSize; boxIndex++)
			{
				var box = _blankGrid.GetBox(boxIndex);
				Assert.That(box.Count(), Is.EqualTo(GridSize));
			}
		}
	}
}