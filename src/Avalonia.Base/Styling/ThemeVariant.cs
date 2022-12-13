using System;
using System.ComponentModel;
using System.Text;

namespace Avalonia.Styling;

[TypeConverter(typeof(ThemeVariantTypeConverter))]
public sealed record ThemeVariant(object Key)
{ 
    public ThemeVariant(object key, ThemeVariant? inheritVariant)
        : this(key)
    {
        InheritVariant = inheritVariant;
    }

    public static ThemeVariant Light { get; } = new(nameof(Light));
    public static ThemeVariant Dark { get; } = new(nameof(Dark));

    public ThemeVariant? InheritVariant { get; init; }

    public override string ToString()
    {
        return Key.ToString() ?? $"ThemeVariant {{ Key = {Key} }}";
    }

    public override int GetHashCode()
    {
        return Key.GetHashCode();
    }

    public bool Equals(ThemeVariant? other)
    {
        return Key == other?.Key;
    }
}
