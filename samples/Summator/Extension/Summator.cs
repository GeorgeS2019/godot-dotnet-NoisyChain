using Godot;
using Godot.Bridge;

namespace GDExtensionSummator;

/// <summary>
/// It sums
/// </summary>
public partial class Summator : RefCounted
{
    private int _count;

    /// <summary>
    /// Adds stuff
    /// </summary>
    /// <param name="value">value to add</param>
    public void Add(int value = 1)
    {
        _count += value;
    }

    /// <summary>
    /// Resets
    /// </summary>
    public void Reset()
    {
        _count = 0;
    }

    /// <summary>
    /// Get values or som
    /// </summary>
    /// <returns>Count</returns>
    public int GetTotal()
    {
        return _count;
    }

    /// <summary>
    /// Dummy
    /// </summary>
    /// <returns>3</returns>
    public static int Dummy()
    {
        return 3;
    }

    internal static void BindMembers(ClassRegistrationContext context)
    {
        context.BindConstructor(() => new Summator());

        context.BindMethod(new StringName(nameof(Add)),
            new ParameterDefinition(new StringName("value"), VariantType.Int, VariantTypeMetadata.Int32, 1),
            static (Summator instance, int value) =>
            {
                instance.Add(value);
            });

        context.BindMethod(new StringName(nameof(Reset)),
            static (Summator instance) =>
            {
                instance.Reset();
            });

        context.BindMethod(new StringName(nameof(GetTotal)),
            new ReturnDefinition(VariantType.Int, VariantTypeMetadata.Int32),
            static (Summator instance) =>
            {
                return instance.GetTotal();
            });

        context.BindStaticMethod(new StringName(nameof(Dummy)),
            new ReturnDefinition(VariantType.Int, VariantTypeMetadata.Int32),
            static () =>
            {
                return Dummy();
            });
    }
}
