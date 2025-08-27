using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(BackpackWheel), nameof(BackpackWheel.Choose))]
public class BackpackWheel_Choose_Patch
{
	public static void Prefix(ref bool __runOriginal)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		// skip the original method (the only way to choose is by clicking; see BackpackWheel_InitWheel_Patch)
		__runOriginal = false;
	}
}
