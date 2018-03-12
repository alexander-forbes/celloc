using System;
using NUnit.Framework;

namespace Celloc.Tests
{
	[TestFixture]
    public class When_calling_translate_on_cell_index
    {
		[Test]
		public void It_should_throw_an_exception_when_the_cell_is_not_in_the_correct_format()
		{
			var exception = Assert.Throws<Exception>(() => CellIndex.Translate("1A"));
			Assert.AreEqual("1A is not a valid cell format.", exception.Message);
		}

		[Test]
		public void It_should_translate_the_cell_to_an_integer_tuple()
		{
			Assert.AreEqual((1,1), CellIndex.Translate("A1"));
			Assert.AreEqual((16384,1048576), CellIndex.Translate("XFD1048576"));
		}

	    [Test]
	    public void It_should_translate_the_cell_to_a_zero_based_integer_tuple()
	    {
		    Assert.AreEqual((0,0), CellIndex.Translate("A1", Offset.ZeroBased));
		    Assert.AreEqual((16383,1048575), CellIndex.Translate("XFD1048576", Offset.ZeroBased));
	    }

	    [Test]
	    public void It_should_throw_an_exception_when_the_cell_parameter_is_null()
	    {
		    var exception = Assert.Throws<ArgumentNullException>(() => CellIndex.Translate(null));
		    Assert.AreEqual($"Value cannot be null.{Environment.NewLine}Parameter name: cell", exception.Message);
	    }

	    [Test]
	    public void It_should_throw_an_exception_when_the_cell_parameter_is_empty()
	    {
		    var exception = Assert.Throws<ArgumentNullException>(() => CellIndex.Translate(string.Empty));
		    Assert.AreEqual($"Value cannot be null.{Environment.NewLine}Parameter name: cell", exception.Message);
	    }

	    [Test]
	    public void It_should_throw_an_exception_when_the_cell_column_is_less_than_0()
	    {
		    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CellIndex.Translate((-1,1)));
		    Assert.AreEqual($"Specified argument was out of the range of valid values.{Environment.NewLine}Parameter name: cell", exception.Message);
	    }

	    [Test]
	    public void It_should_throw_an_exception_when_the_cell_row_is_less_than_0()
	    {
		    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CellIndex.Translate((1, -1)));
		    Assert.AreEqual($"Specified argument was out of the range of valid values.{Environment.NewLine}Parameter name: cell", exception.Message);
	    }

	    [Test]
	    public void It_should_throw_an_exception_when_the_cell_column_is_less_than_1_and_offset_is_none()
	    {
		    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CellIndex.Translate((0, 1)));
		    Assert.AreEqual($"Specified argument was out of the range of valid values.{Environment.NewLine}Parameter name: cell", exception.Message);
	    }

	    [Test]
	    public void It_should_throw_an_exception_when_the_cell_row_is_less_than_1_and_offset_is_none()
	    {
		    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CellIndex.Translate((1, 0)));
		    Assert.AreEqual($"Specified argument was out of the range of valid values.{Environment.NewLine}Parameter name: cell", exception.Message);
	    }

	    [Test]
	    public void It_should_not_throw_an_exception_when_the_cell_column_is_less_than_1_and_offset_is_zero_based()
	    {
		    Assert.DoesNotThrow(() => CellIndex.Translate((0, 1), Offset.ZeroBased));
	    }

	    [Test]
	    public void It_should_not_throw_an_exception_when_the_cell_row_is_less_than_1_and_offset_is_zero_based()
	    {
		    Assert.DoesNotThrow(() => CellIndex.Translate((1, 0), Offset.ZeroBased));
	    }

		[Test]
		public void It_should_translate_the_cell_to_a_string()
		{
			Assert.AreEqual("A1", CellIndex.Translate((1, 1)));
			Assert.AreEqual("XFD1048576", CellIndex.Translate((16384, 1048576)));
		}

	    [Test]
	    public void It_should_translate_the_cell_to_a_zero_based_string()
	    {
		    Assert.AreEqual("A1", CellIndex.Translate((0, 0), Offset.ZeroBased));
		    Assert.AreEqual("XFD1048576", CellIndex.Translate((16384, 1048576)));
	    }
	}
}
