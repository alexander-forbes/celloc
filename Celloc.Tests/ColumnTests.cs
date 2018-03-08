using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Celloc.Tests
{
	[TestFixture]
	public class When_calling_convert_to_number_on_column
	{
		[Test]
		public void It_should_convert_a_lower_case_column_name_to_the_corresponding_column_number()
		{
			Assert.AreEqual(1, Column.ConvertToNumber("a"));
			Assert.AreEqual(16384, Column.ConvertToNumber("xfd"));
		}

		[Test]
		public void It_should_convert_an_upper_case_column_name_to_the_corresponding_column_number()
		{
			Assert.AreEqual(1, Column.ConvertToNumber("A"));
			Assert.AreEqual(16384, Column.ConvertToNumber("XFD"));
		}

		[Test]
		public void It_should_throw_an_exception_when_the_column_parameter_is_null()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => Column.ConvertToNumber(null));
			Assert.AreEqual($"Value cannot be null.{Environment.NewLine}Parameter name: column", exception.Message);
		}

		[Test]
		public void It_should_throw_an_exception_when_the_column_parameter_is_empty()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => Column.ConvertToNumber(string.Empty));
			Assert.AreEqual($"Value cannot be null.{Environment.NewLine}Parameter name: column", exception.Message);
		}
	}
}
