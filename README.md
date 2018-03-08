[![Build Status](https://travis-ci.org/sduplooy/Celloc.svg?branch=master)](https://travis-ci.org/sduplooy/Celloc)
[![NuGet Badge](https://buildstats.info/nuget/Celloc)](https://www.nuget.org/packages/Celloc/)

# Celloc
An Excel cell index converter.

## NuGet
To install the package from NuGet, run the following command:
`Install-Package Celloc`

## Usage
To translate a cell value to a zero-based index, specify the cell index and the offset type as `Offset.ZeroBased`:

### Cells
```C#
CellIndex.Translate("A1", Offset.ZeroBased) //(0,0)
```

To translate a cell value to a non-zero based index, specify the cell index and the offset type as `Offset.None`: 

```C#
CellIndex.Translate("A1", Offset.None) //(1,1)
```

### Ranges
To translate a range to a zero-based index, specify the cell index and the offset type as `Offset.ZeroBased`:

```C#
CellIndex.Translate("A1:B3", Offset.ZeroBased) //((0,0),(1,2))
```

To translate a range to a non-zero based index, specify the cell index and the offset type as `Offset.None`: 

```C#
CellRange.Translate("A1:B3", Offset.None) //((1,1),(2,3))
```

The default `Offset` is `None`.

Algorithm by [Ian Nelson](https://stackoverflow.com/a/667902/31770).
