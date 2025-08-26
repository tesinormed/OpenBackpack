using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(BackpackWheelSlice), nameof(BackpackWheelSlice.Hover))]
public class BackpackWheelSlice_Hover_Patch
{
	public static void Prefix(BackpackWheelSlice __instance, ref bool __runOriginal)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		// don't ignore if it has an item
		if (__instance.hasItem) return;

		// ignore hover
		__runOriginal = false;
	}
}
