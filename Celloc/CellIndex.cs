using System;

namespace Celloc
{
	public static class CellIndex
	{
		public static (int Column, int Row) Translate(string cell, Offset offset = Offset.None)
		{
			if (string.IsNullOrEmpty(cell))
				throw new ArgumentNullException(nameof(cell));

			var (column, row) = Cell.Parse(cell);

			return ApplyOffset(offset, column, row);
		}

		private static (int Column, int Row) ApplyOffset(Offset offset, int column, int row)
		{
			return offset == Offset.None ?
				(column, row) :
				(column - 1, row - 1);
		}

		public static string Translate((int Column, int Row) cell, Offset offset = Offset.None)
		{
			if (cell.Column < (offset == Offset.ZeroBased ? 0 : 1))
				throw new ArgumentOutOfRangeException(nameof(cell));

			if (cell.Row < (offset == Offset.ZeroBased ? 0 : 1))
				throw new ArgumentOutOfRangeException(nameof(cell));

			return offset == Offset.ZeroBased ?
				$"{Column.ConvertToString(cell.Column + 1)}{cell.Row + 1}" :
				$"{Column.ConvertToString(cell.Column)}{cell.Row}";
		}
	}
}
