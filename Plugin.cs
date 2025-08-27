using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack;

[BepInAutoPlugin]
public partial class Plugin : BaseUnityPlugin
{
	internal new static ManualLogSource Logger = null!;
	private static Harmony _harmony = null!;
	internal static bool IsModifiedBackpackWheel = false;

	private void Awake()
	{
		Logger = base.Logger;
		_harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), Id);
	}

	// for https://github.com/Hamunii/AutoReload
	private void OnDestroy()
	{
		_harmony.UnpatchSelf();
		IsModifiedBackpackWheel = false;
	}
}
