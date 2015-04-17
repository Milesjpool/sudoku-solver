using System;
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

		public IEnumerable<Cell> GetRow(int rowIndex)
		{
			return _cells.Where(b => b.Row == rowIndex);
		}

		public IEnumerable<Cell> GetColumn(int colIndex)
		{
			return _cells.Where(b => b.Col == colIndex);
		}

		public IEnumerable<Cell> GetBox(int boxIndex)
		{
			return _cells.Where(b => b.Box == boxIndex);
		}

		public void PutValue(int rowIndex, int colIndex, int value)
		{
			_cells.Single(b => (b.Row == rowIndex) && (b.Col == colIndex)).SetValue(value);
		}
	}
}