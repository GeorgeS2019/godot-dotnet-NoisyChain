using Godot;
using Godot.Bridge;

namespace OtherThings;

/// <summary>
/// A test node
/// </summary>
public partial class DummyNode : Node
{
    /// <summary>
    /// Main value
    /// </summary>
    private double value;

    /// <summary>
    /// Sets the valye
    /// </summary>
    /// <param name="newValue">value to set</param>
    public void SetValue(double newValue)
    {
        value = newValue;
    }

    /// <summary>
    /// Gets the value
    /// </summary>
    /// <returns>value</returns>
    public double GetValue()
    {
        return value;
    }

    /// <summary>
    /// test virtual method
    /// </summary>
    public virtual void ModifyThis() { }

    internal static void BindMembers(ClassRegistrationContext context)
    {
        context.BindConstructor(() => new DummyNode());

        context.BindMethod(new StringName(nameof(SetValue)),
            new ParameterDefinition(new StringName("value"), VariantType.Float, VariantTypeMetadata.Double, 0),
            static (DummyNode instance, double value) =>
            {
                instance.SetValue(value);
            });

        context.BindMethod(new StringName(nameof(GetValue)),
            new ReturnDefinition(VariantType.Float, VariantTypeMetadata.Double),
            static (DummyNode instance) =>
            {
                return instance.GetValue();
            });

        context.BindMethod(new StringName(nameof(ModifyThis)),
            static (DummyNode instance) =>
            {
                instance.ModifyThis();
            });

        context.BindProperty(new PropertyDefinitionWithAccessors(
            new StringName(nameof(value)), VariantType.Float, new StringName(nameof(GetValue)), new StringName(nameof(SetValue))
        ));

        context.BindVirtualMethod(new StringName(nameof(ModifyThis)));
    }
}