using System;
using System.Text.RegularExpressions;

namespace Celloc
{
	internal static class Cell
	{
		private const string ColumnRowPattern = "^(?<column>[a-zA-Z]+)(?<row>[0-9]+)$";

		public static (int Column, int Row) Parse(string cell)
		{
			if (string.IsNullOrEmpty(cell))
				throw new ArgumentNullException(nameof(cell));

			var regex = new Regex(ColumnRowPattern);
			var match = regex.Match(cell);

			if (!match.Success)
				throw new Exception($"{cell} is not a valid cell format.");

			var column = Column.ConvertToNumber(match.Groups["column"].Value);
			var row = Convert.ToInt32(match.Groups["row"].Value);

			return (column, row);
		}
	}
}
