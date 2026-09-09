using FixMath.NET;
using Godot;
using Godot.Bridge;

namespace OtherThings;

/// <summary>
/// Idk anymore man...
/// </summary>
public partial class FixedSharp : RefCounted
{
    private Fix64 value;

    /// <summary>
    /// Sets the raw valye
    /// </summary>
    /// <param name="newValue">value to set</param>
    public void SetRawValue(long newValue)
    {
        value = Fix64.FromRaw(newValue);
    }

    /// <summary>
    /// Gets the raw value
    /// </summary>
    /// <returns>value</returns>
    public long GetRawValue()
    {
        return value.RawValue;
    }

    internal static void BindMembers(ClassRegistrationContext context)
    {
        context.BindConstructor(() => new FixedSharp());

        context.BindMethod(new StringName(nameof(SetRawValue)),
            new ParameterDefinition(new StringName("value"), VariantType.Int, VariantTypeMetadata.Int64, 0),
            static (FixedSharp instance, long value) =>
            {
                instance.SetRawValue(value);
            });

        context.BindMethod(new StringName(nameof(SetRawValue)),
            new ReturnDefinition(VariantType.Int, VariantTypeMetadata.Int64),
            static (FixedSharp instance) =>
            {
                return instance.GetRawValue();
            });

        context.BindProperty(new PropertyDefinitionWithAccessors(
            new StringName("raw_value"), VariantType.Int, new StringName(nameof(GetRawValue)), new StringName(nameof(SetRawValue))
        ));
    }
}