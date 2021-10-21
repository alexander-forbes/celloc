using System;
using System.Text.RegularExpressions;

namespace Celloc
{
	public static class CellRange
	{
		private const string RangePattern = "^(?<fromColumn>[a-zA-Z]{0,3})(?<fromRow>[0-9]+):(?<toColumn>[a-zA-Z]{0,3})(?<toRow>[0-9]+)$";

		public static ((int Column, int Row), (int Column, int Row)) Translate(string range, Offset offset = Offset.None)
		{
			GuardAgainstNullRange(range);

			var regex = new Regex(RangePattern);
			var match = regex.Match(range);

			if (!match.Success)
				throw new Exception($"{range} is not a valid range format.");

			var cells = range.Split(':');

			var fromCell = Cell.Parse(cells[0]);
			var toCell = Cell.Parse(cells[1]);

			return ApplyOffset(offset, fromCell, toCell);
		}

		private static ((int Column, int Row), (int Column, int Row)) ApplyOffset(Offset offset,
			(int Column, int Row) fromCell, (int Column, int Row) toCell)
		{
			return offset == Offset.None ?
				((fromCell.Column, fromCell.Row), (toCell.Column, toCell.Row)) :
				((fromCell.Column - 1, fromCell.Row - 1), (toCell.Column - 1, toCell.Row - 1));
		}

		public static string Translate(((int Column, int Row), (int Column, int Row)) range, Offset offset = Offset.None)
		{
			var fromCell = CellIndex.Translate(range.Item1, offset);
			var toCell = CellIndex.Translate(range.Item2, offset);

			return $"{fromCell}:{toCell}";
		}

		public static bool IsSameColumn(((int Column, int Row), (int Column, int Row)) range)
		{
			return Equals(range.Item1.Column, range.Item2.Column);
		}

		public static bool IsSameRow(((int Column, int Row), (int Column, int Row)) range)
		{
			return Equals(range.Item1.Row, range.Item2.Row);
		}

		public static bool IsSameColumn(string range)
		{
			GuardAgainstNullRange(range);

			var tuple = Translate(range);
			return IsSameColumn(tuple);
		}

		public static bool IsSameRow(string range)
		{
			GuardAgainstNullRange(range);

			var tuple = Translate(range);
			return IsSameRow(tuple);
		}

		private static void GuardAgainstNullRange(string range)
		{
			if (string.IsNullOrEmpty(range))
				throw new ArgumentNullException(nameof(range));
		}
	}
}
