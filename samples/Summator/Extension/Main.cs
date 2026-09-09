// ./build.cmd --productBuild --pushNupkgsLocal ~/MyLocalNuGetSource /p:GenerateGodotBindings=true --warnAsError false
// cd samples/Summator
// dotnet publish Extension -c Debug -r win-x64 -o Game/lib/windows --self-contained true

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Godot;
using Godot.Bridge;
using FixMath.NET;
using OtherThings;

[assembly: DisableGodotEntryPointGeneration]
[assembly: DisableRuntimeMarshalling]

namespace GDExtensionSummator;

public class Main
{
    public static void InitializeSummatorTypes(InitializationLevel level)
    {
        if (level != InitializationLevel.Scene)
        {
            return;
        }

        GodotRegistry.RegisterClass<Summator>(Summator.BindMembers);
        GodotRegistry.RegisterClass<FixedSharp>(FixedSharp.BindMembers);
        GodotRegistry.RegisterClass<DummyNode>(DummyNode.BindMembers);
    }

    public static void DeinitializeSummatorTypes(InitializationLevel level)
    {
        if (level != InitializationLevel.Scene)
        {
            return;
        }
    }

    // Initialization

    [UnmanagedCallersOnly(EntryPoint = "summator_library_init")]
    public static bool SummatorLibraryInit(nint getProcAddress, nint library, nint initialization)
    {
        GodotBridge.Initialize(getProcAddress, library, initialization, config =>
        {
            config.SetMinimumLibraryInitializationLevel(InitializationLevel.Scene);
            config.RegisterInitializer(InitializeSummatorTypes);
            config.RegisterTerminator(DeinitializeSummatorTypes);
        });

        return true;
    }
}
