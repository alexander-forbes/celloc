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
	}
}
