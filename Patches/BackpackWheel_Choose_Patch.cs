using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(BackpackWheel), nameof(BackpackWheel.Choose))]
public class BackpackWheel_Choose_Patch
{
	public static void Prefix(ref bool __runOriginal)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		// disable original code
		__runOriginal = false;
	}
}
