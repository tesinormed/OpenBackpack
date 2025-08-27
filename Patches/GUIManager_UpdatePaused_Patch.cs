using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(GUIManager), nameof(GUIManager.UpdatePaused))]
internal static class GUIManager_UpdatePaused_Patch
{
	public static void Prefix(GUIManager __instance, ref bool __runOriginal)
	{
		if (!Character.localCharacter.input.pauseWasPressed || !Plugin.IsModifiedBackpackWheel) return;

		Plugin.Logger.LogInfo("closing modified backpack wheel");
		__runOriginal = false;
		Character.localCharacter.input.pauseWasPressed = false; // from the original method
		__instance.CloseBackpackWheel();
	}
}
