using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(GUIManager), nameof(GUIManager.UpdatePaused))]
public class GUIManager_UpdatePaused_Patch
{
	public static void Prefix(GUIManager __instance, ref bool __runOriginal)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		// the pause button must be pressed
		if (!Character.localCharacter.input.pauseWasPressed) return;

		Plugin.Logger.LogInfo("closing modified backpack wheel");
		__runOriginal = false;
		Character.localCharacter.input.pauseWasPressed = false; // from the original method
		__instance.CloseBackpackWheel();
	}
}
