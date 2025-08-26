using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(GUIManager), nameof(GUIManager.CloseBackpackWheel))]
public class GUIManager_CloseBackpackWheel_Patch
{
	public static void Postfix(GUIManager __instance)
	{
		// reset IsModifiedBackpackWheel to false
		Plugin.IsModifiedBackpackWheel = false;

		// remove click listeners from BackpackWheel_InitWheel_Patch
		foreach (var backpackWheelSlice in __instance.backpackWheel.slices) backpackWheelSlice.button.onClick.RemoveAllListeners();
	}
}
