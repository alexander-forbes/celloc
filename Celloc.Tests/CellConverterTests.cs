using System;
using NUnit.Framework;

namespace Celloc.Tests
{
	[TestFixture]
    public class When_calling_convert_on_cell_converter
    {
		[Test]
		public void It_should_throw_an_exception_when_the_row_is_out_of_range()
		{
			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CellConverter.Parse("XFE1048577"));
			Assert.AreEqual("Row must be greater than 0 and less than 1048576.\r\nParameter name: row", exception.Message);
		}

		[Test]
		public void It_should_throw_an_exception_when_the_cell_is_not_in_the_correct_format()
		{
			var exception = Assert.Throws<Exception>(() => CellConverter.Parse("1A"));
			Assert.AreEqual("1A is not a valid cell format.", exception.Message);
		}

		[Test]
		public void It_should_convert_the_cell_to_an_integer_tuple()
		{
			Assert.AreEqual(new Tuple<int, int>(1, 1), CellConverter.Parse("A1"));
			Assert.AreEqual(new Tuple<int, int>(16384, 1048576), CellConverter.Parse("XFD1048576"));
		}

	    [Test]
	    public void It_should_convert_the_cell_to_a_zero_based_integer_tuple()
	    {
		    Assert.AreEqual(new Tuple<int, int>(0, 0), CellConverter.Parse("A1", Offset.ZeroBased));
		    Assert.AreEqual(new Tuple<int, int>(16383, 1048575), CellConverter.Parse("XFD1048576", Offset.ZeroBased));
	    }
	}
}
