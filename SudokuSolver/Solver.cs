namespace SudokuSolver
{
	public class Solver
	{
		private readonly Grid _grid;

		public Solver(Grid grid)
		{
			_grid = grid;
		}

		public void SolveRow(int rowIndex)
		{
			var row = _grid.GetRow(rowIndex);
			foreach (var cell in row.UnsolvedCells())
			{
				TrySolve(cell, row);
			}
		}

		public void SolveCol(int colIndex)
		{
			var col = _grid.GetColumn(colIndex);
			foreach (var cell in col.UnsolvedCells())
			{
				TrySolve(cell, col);
			}
		}

		public void SolveBox(int boxIndex)
		{
			var box = _grid.GetBox(boxIndex);
			foreach (var cell in box.UnsolvedCells())
			{
				TrySolve(cell, box);
			}
		}

		private void TrySolve(Cell unsolvedCell, CellGrouping group)
		{
			foreach (var value in group.FoundValues())
			{
				unsolvedCell.CantBe(value);
			}
		}
	}
}