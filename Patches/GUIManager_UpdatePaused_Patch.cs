using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(GUIManager), nameof(GUIManager.UpdatePaused))]
public class GUIManager_UpdatePaused_Patch
{
	public static void Prefix(ref bool __runOriginal)
	{
		if (!Character.localCharacter.input.pauseWasPressed || !Plugin.WasModifiedBackpackWheel) return;

		Plugin.Logger.LogInfo("ignoring pause button press");
		Plugin.WasModifiedBackpackWheel = false;
		__runOriginal = false;
	}
}
