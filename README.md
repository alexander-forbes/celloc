[![Build Status](https://travis-ci.org/sduplooy/Celloc.svg?branch=master)](https://travis-ci.org/sduplooy/Celloc)
[![NuGet Badge](https://buildstats.info/nuget/Celloc)](https://www.nuget.org/packages/Celloc/)

# Celloc
An Excel cell index converter.

## NuGet
To install the package from NuGet, run the following command:
`Install-Package Celloc`

## Usage

### Cells
To translate a cell value to a zero-based tuple, specify the cell and the offset type as `Offset.ZeroBased`:

```C#
CellIndex.Translate("A1", Offset.ZeroBased) //(0,0)
```

To translate a cell value to a non-zero based tuple, specify the cell and the offset type as `Offset.None`: 

```C#
CellIndex.Translate("A1", Offset.None) //(1,1)
```

To translate an integer tuple to a name, specify the cell and the offset type as `Offset.None`: 

```C#
CellIndex.Translate((1,1), Offset.None) //"A1"
```

To translate a zero-based integer tuple to a name, specify the cell and the offset type as `Offset.ZeroBased`: 

```C#
CellIndex.Translate((0,0), Offset.ZeroBased) //"A1"
```

### Ranges
To translate a range to a zero-based tuple, specify the range and the offset type as `Offset.ZeroBased`:

```C#
CellRange.Translate("A1:B3", Offset.ZeroBased) //((0,0),(1,2))
```

To translate a range to a non-zero based tuple, specify the range and the offset type as `Offset.None`: 

```C#
CellRange.Translate("A1:B3", Offset.None) //((1,1),(2,3))
```

The default `Offset` is `None`.

Algorithms by [Ian Nelson](https://stackoverflow.com/a/667902/31770) and [Graham](https://stackoverflow.com/a/182924/31770).
