using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Exceptions;

namespace SudokuSolver
{
	public class Cell
	{
		private readonly List<int> _potentialValues;
		public int Row { get; private set; }
		public int Col { get; private set; }
		public int Box { get; private set; }
		public int Value { get;  private set; }
		public bool Solved { get; private set; }

		public Cell(int row, int col)
		{
			Row = row;
			Col = col;
			Box = boxContaining(row, col);
			_potentialValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		}

		public void SetValue(int val)
		{
			if (val < 1 || val > 9) throw new InvalidValueException();
			if (Value != 0) throw new CellAlreadyHasValueException();
			Value = val;
			MarkAsSolved();
		}

		public void CantBe(int val)
		{
			if (Value != 0) throw new CellAlreadyHasValueException();
			_potentialValues.Remove(val);
			if (_potentialValues.Count == 1) SetValue(_potentialValues.Single());
		}

		private int boxContaining(int row, int col)
		{
			var sqRow = row / 3;
			var sqCol = col / 3;
			return sqRow * 3 + sqCol;
		}

		private void MarkAsSolved()
		{
			Solved = true;
			_potentialValues.RemoveAll(i => true);
		}
	}
}
