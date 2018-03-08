using System;

namespace Celloc
{
	internal static class Column
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
				sum += (letter - 'A' + 1);
			}

			return sum;
		}
	}
}
