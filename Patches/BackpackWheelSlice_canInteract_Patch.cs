using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(BackpackWheelSlice), nameof(BackpackWheelSlice.canInteract), MethodType.Getter)]
internal static class BackpackWheelSlice_canInteract_Patch
{
	public static void Prefix(BackpackWheelSlice __instance, ref bool __runOriginal, ref bool __result)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		// interactability only depends on if the slice has an item (cannot wear backpack, cannot stash item)
		__runOriginal = false;
		__result = __instance.hasItem;
	}
}
