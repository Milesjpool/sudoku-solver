using System.Collections.Generic;
using NUnit.Framework;
using SudokuSolver.Exceptions;

namespace SudokuSolver.Unit.Tests
{
	public class CellMethodTests
	{
		private Cell _cell;

		[SetUp]
		public void Setup()
		{
			_cell = new Cell(0, 0);
		}

		[TestCase(0, 0, 0)]
		[TestCase(1, 4, 1)]
		[TestCase(2, 8, 2)]
		[TestCase(4, 4, 4)]
		[TestCase(8, 8, 8)]
		public void Cell_constructor_should_set_correct_box_index(int row, int column, int expectedbox)
		{
			var cell = new Cell(row, column);
			Assert.That(cell.Box, Is.EqualTo(expectedbox));
		}

		[Test]
		public void Value_of_cell_can_be_set()
		{
			_cell.SetValue(1);
			Assert.That(_cell.Value, Is.EqualTo(1));
		}

		[TestCase(10)]
		[TestCase(0)]
		public void Cell_can_only_take_valid_values(int val)
		{
			Assert.Throws<InvalidValueException>(() => _cell.SetValue(val));
		}

		[Test]
		public void Cell_value_can_only_be_set_once()
		{
			_cell.SetValue(1);
			Assert.Throws<CellAlreadyHasValueException>(() => _cell.SetValue(2));
		}

		[TestCase(5)]
		[TestCase(8)]
		public void Cell_value_is_set_once_all_other_potential_values_are_depleted(int val)
		{
			var ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			ints.Remove(val);
			foreach (var i in ints)
			{
				_cell.CantBe(i);
			}
			Assert.That(_cell.Value, Is.EqualTo(val));
		}

		[Test]
		public void Should_throw_exception_if_a_potential_value_is_removed_from_a_cell_with_a_value()
		{
			_cell.SetValue(1);
			Assert.Throws<CellAlreadyHasValueException>(() => _cell.CantBe(2));
		}
	}
}