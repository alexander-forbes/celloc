using System;
using NUnit.Framework;

namespace Celloc.Tests
{
	[TestFixture]
	public class When_calling_translate_on_cell_range
	{
		[Test]
		public void It_should_throw_an_exception_when_the_range_is_not_in_the_correct_format()
		{
			var exception = Assert.Throws<Exception>(() => CellRange.Translate("1A"));
			Assert.AreEqual("1A is not a valid range format.", exception.Message);
		}

		[Test]
		public void It_should_convert_the_range_to_a_tuple()
		{
			Assert.AreEqual(((1, 1), (1, 1)), CellRange.Translate("A1:A1"));
			Assert.AreEqual(((1, 1), (16384, 1048576)), CellRange.Translate("A1:XFD1048576"));
		}

		[Test]
		public void It_should_convert_the_range_to_a_zero_based_tuple()
		{
			Assert.AreEqual(((0, 0), (0, 0)), CellRange.Translate("A1:A1", Offset.ZeroBased));
			Assert.AreEqual(((0, 0), (16383, 1048575)), CellRange.Translate("A1:XFD1048576", Offset.ZeroBased));
		}

		[Test]
		public void It_should_throw_an_exception_when_the_range_parameter_is_null()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => CellRange.Translate(null));
			Assert.AreEqual($"Value cannot be null. (Parameter 'range')", exception.Message);
		}

		[Test]
		public void It_should_throw_an_exception_when_the_range_parameter_is_empty()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => CellRange.Translate(string.Empty));
			Assert.AreEqual($"Value cannot be null. (Parameter 'range')", exception.Message);
		}

		[Test]
		public void It_should_convert_the_range_tuple_to_a_string()
		{
			Assert.AreEqual("A1:A1", CellRange.Translate(((1, 1), (1, 1))));
			Assert.AreEqual("A1:XFD1048576", CellRange.Translate(((1, 1), (16384, 1048576))));
		}

		[Test]
		public void It_should_convert_the_zero_based_range_tuple_to_a_string()
		{
			Assert.AreEqual("A1:A1", CellRange.Translate(((0, 0), (0, 0)), Offset.ZeroBased));
			Assert.AreEqual("A1:XFD1048576", CellRange.Translate(((0, 0), (16383, 1048575)), Offset.ZeroBased));
		}
	}

	[TestFixture]
	public class When_calling_is_same_row_on_cell_range
	{
		[Test]
		public void It_should_throw_an_exception_when_the_range_parameter_is_null()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => CellRange.IsSameRow(null));
			Assert.AreEqual($"Value cannot be null. (Parameter 'range')", exception.Message);
		}

		[Test]
		public void It_should_return_true_when_the_range_is_for_the_same_row()
		{
			Assert.IsTrue(CellRange.IsSameRow("A1:D1"));
		}

		[Test]
		public void It_should_return_false_when_the_range_is_not_for_the_same_row()
		{
			Assert.IsFalse(CellRange.IsSameRow("A1:A20"));
		}

		[Test]
		public void It_should_return_true_when_the_range_tuple_is_for_the_same_row()
		{
			Assert.IsTrue(CellRange.IsSameRow(((0, 0), (20, 0))));
		}

		[Test]
		public void It_should_return_false_when_the_range_tuple_is_not_for_the_same_row()
		{
			Assert.IsFalse(CellRange.IsSameRow(((0, 0), (0, 20))));
		}
	}

	[TestFixture]
	public class When_calling_is_same_column_on_cell_range
	{
		[Test]
		public void It_should_throw_an_exception_when_the_range_parameter_is_null()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => CellRange.IsSameColumn(null));
			Assert.AreEqual($"Value cannot be null. (Parameter 'range')", exception.Message);
		}

		[Test]
		public void It_should_return_true_when_the_range_is_for_the_same_column()
		{
			Assert.IsTrue(CellRange.IsSameColumn("A1:A20"));
		}

		[Test]
		public void It_should_return_false_when_the_range_is_not_for_the_same_column()
		{
			Assert.IsFalse(CellRange.IsSameColumn("A1:D1"));
		}

		[Test]
		public void It_should_return_true_when_the_range_tuple_is_for_the_same_column()
		{
			Assert.IsTrue(CellRange.IsSameColumn(((0, 0), (0, 20))));
		}

		[Test]
		public void It_should_return_false_when_the_range_tuple_is_not_for_the_same_column()
		{
			Assert.IsFalse(CellRange.IsSameColumn(((0, 0), (4, 0))));
		}
	}
}
