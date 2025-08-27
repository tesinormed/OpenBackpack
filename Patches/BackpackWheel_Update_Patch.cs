using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(BackpackWheel), nameof(BackpackWheel.Update))]
internal static class BackpackWheel_Update_Patch
{
	public static void Prefix(ref bool __runOriginal)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		// skip the original method
		__runOriginal = false;
	}
}
