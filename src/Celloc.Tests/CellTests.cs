using System;
using NUnit.Framework;

namespace Celloc.Tests
{
	[TestFixture]
	public class When_calling_parse_on_cell
	{
		[Test]
		public void It_should_return_the_column_and_row_of_the_cell()
		{
			Assert.AreEqual((1, 1), Cell.Parse("A1"));
			Assert.AreEqual((16384, 1), Cell.Parse("XFD1"));
		}

		[Test]
		public void It_should_throw_an_exception_when_the_cell_parameter_is_null()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => Cell.Parse(null));
			Assert.AreEqual($"Value cannot be null. (Parameter 'cell')", exception.Message);
		}

		[Test]
		public void It_should_throw_an_exception_when_the_cell_parameter_is_empty()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => Cell.Parse(string.Empty));
			Assert.AreEqual($"Value cannot be null. (Parameter 'cell')", exception.Message);
		}
	}
}
