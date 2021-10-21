using System;

namespace Celloc
{
	public static class Column
	{
		public static int ConvertToNumber(string column)
		{
			if (string.IsNullOrEmpty(column))
				throw new ArgumentNullException(nameof(column));

			column = column.ToUpperInvariant();

			var sum = 0;

			foreach (var letter in column)
			{
				sum *= 26;
				sum += letter - 'A' + 1;
			}

			return sum;
		}

		public static string ConvertToString(int column)
		{
			if (column < 1)
				throw new ArgumentOutOfRangeException(nameof(column));

			var dividend = column;
			var columnName = string.Empty;

			while (dividend > 0)
			{
				var modulo = (dividend - 1) % 26;
				columnName = Convert.ToChar('A' + modulo) + columnName;
				dividend = (dividend - modulo) / 26;
			}

			return columnName;
		}
	}
}
