using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
	public class CellGrouping
	{
		private readonly IEnumerable<Cell> _cells;

		public CellGrouping(IEnumerable<Cell> cells)
		{
			_cells = cells;
		}

		public int Count()
		{
			return _cells.Count();
		}

		public IEnumerable<Cell> UnsolvedCells()
		{
			return _cells.Where(c => !c.Solved);
		}

		public IEnumerable<Cell> SolvedCells()
		{
			return _cells.Where(c => c.Solved);
		}

		public bool IsSolved()
		{
			return _cells.All(c => c.Solved);
		}

		public IEnumerable<int> FoundValues()
		{
			return _cells.Where(c => c.Solved).Select(s => s.Value);
		}
	}
}