using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
	public class Grid
	{
		private readonly List<Cell> _cells = new List<Cell>();
		private const int GridSize = 9;

		public Grid()
		{
			for (int row = 0; row < GridSize; row++)
			{
				for (int col = 0; col < GridSize; col++)
				{
					_cells.Add(new Cell(row, col));
				}
			}
		}

		public int Count { get { return _cells.Count; } }

		public Cell GetCell(int rowIndex, int colIndex)
		{
			return _cells.Single(c => ((c.Row == rowIndex) && (c.Col == colIndex)));
		}

		public CellGrouping GetRow(int rowIndex)
		{
			var cells = _cells.Where(b => b.Row == rowIndex);
			return new CellGrouping(cells);
		}

		public CellGrouping GetColumn(int colIndex)
		{
			var cells = _cells.Where(b => b.Col == colIndex);
			return new CellGrouping(cells);
		}

		public CellGrouping GetBox(int boxIndex)
		{
			var cells = _cells.Where(b => b.Box == boxIndex);
			return new CellGrouping(cells);
		}

		public void PutValue(int rowIndex, int colIndex, int value)
		{
			GetCell(rowIndex, colIndex).SetValue(value);
		}
	}
}