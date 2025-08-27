using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(GUIManager), nameof(GUIManager.CloseBackpackWheel))]
public class GUIManager_CloseBackpackWheel_Patch
{
	public static void Postfix(GUIManager __instance)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		// reset to false
		Plugin.IsModifiedBackpackWheel = false;

		// remove the click listeners that were added by BackpackWheel_InitWheel_Patch
		foreach (var backpackWheelSlice in __instance.backpackWheel.slices) backpackWheelSlice.button.onClick.RemoveAllListeners();
	}
}
