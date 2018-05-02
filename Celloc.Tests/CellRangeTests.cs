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
		public void It_should_convert_the_range_to_an_integer_tuple()
		{
			Assert.AreEqual(((1, 1), (1, 1)), CellRange.Translate("A1:A1"));
			Assert.AreEqual(((1, 1), (16384, 1048576)), CellRange.Translate("A1:XFD1048576"));
		}

		[Test]
		public void It_should_convert_the_range_to_a_zero_based_integer_tuple()
		{
			Assert.AreEqual(((0, 0), (0, 0)), CellRange.Translate("A1:A1", Offset.ZeroBased));
			Assert.AreEqual(((0, 0), (16383, 1048575)), CellRange.Translate("A1:XFD1048576", Offset.ZeroBased));
		}

		[Test]
		public void It_should_throw_an_exception_when_the_range_parameter_is_null()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => CellRange.Translate(null));
			Assert.AreEqual($"Value cannot be null.{Environment.NewLine}Parameter name: range", exception.Message);
		}

		[Test]
		public void It_should_throw_an_exception_when_the_range_parameter_is_empty()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => CellRange.Translate(string.Empty));
			Assert.AreEqual($"Value cannot be null.{Environment.NewLine}Parameter name: range", exception.Message);
		}

		[Test]
		public void It_should_convert_the_range_integer_tuple_to_a_string()
		{
			Assert.AreEqual("A1:A1", CellRange.Translate(((1, 1), (1, 1))));
			Assert.AreEqual("A1:XFD1048576", CellRange.Translate(((1, 1), (16384, 1048576))));
		}

		[Test]
		public void It_should_convert_the_zero_based_range_integer_tuple_to_a_string()
		{
			Assert.AreEqual("A1:A1", CellRange.Translate(((0, 0), (0, 0)), Offset.ZeroBased));
			Assert.AreEqual("A1:XFD1048576", CellRange.Translate(((0, 0), (16383, 1048575)), Offset.ZeroBased));
		}
	}
}
