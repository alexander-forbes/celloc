# Celloc
An Excel cell index converter.

## Usage

To translate a cell value to a zero-based index, specify the cell index and the offset type as `Offset.ZeroBased`:

```C#
CellIndex.Translate("A1", Offset.ZeroBased) //(0,0)
```

To translate a cell value to a non-zero based index, specify the cell index and the offset type as `Offset.None`: 

```c#
CellIndex.Translate("A1", Offset.None) //(1,1)
```

The default `Offset` is `None`.

