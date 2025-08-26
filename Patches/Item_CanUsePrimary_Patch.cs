using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(Item), nameof(Item.CanUsePrimary))]
public class Item_CanUsePrimary_Patch
{
	public static void Prefix(Item __instance, ref bool __runOriginal, ref bool __result)
	{
		if (__instance is not Backpack) return;

		// force CanUsePrimary to always return true
		__runOriginal = false;
		__result = true;
	}
}
