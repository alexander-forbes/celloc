using System;
using NUnit.Framework;

namespace Celloc.Tests
{
	[TestFixture]
    public class When_calling_transalte_on_cell_index
    {
		[Test]
		public void It_should_throw_an_exception_when_the_row_is_out_of_range()
		{
			var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CellIndex.Translate("XFE1048577"));
			Assert.AreEqual($"Row must be greater than 0 and less than 1048576.{Environment.NewLine}Parameter name: row", exception.Message);
		}

		[Test]
		public void It_should_throw_an_exception_when_the_cell_is_not_in_the_correct_format()
		{
			var exception = Assert.Throws<Exception>(() => CellIndex.Translate("1A"));
			Assert.AreEqual("1A is not a valid cell format.", exception.Message);
		}

		[Test]
		public void It_should_convert_the_cell_to_an_integer_tuple()
		{
			Assert.AreEqual((1, 1), CellIndex.Translate("A1"));
			Assert.AreEqual((16384, 1048576), CellIndex.Translate("XFD1048576"));
		}

	    [Test]
	    public void It_should_convert_the_cell_to_a_zero_based_integer_tuple()
	    {
		    Assert.AreEqual((0, 0), CellIndex.Translate("A1", Offset.ZeroBased));
		    Assert.AreEqual((16383, 1048575), CellIndex.Translate("XFD1048576", Offset.ZeroBased));
	    }
	}
}
