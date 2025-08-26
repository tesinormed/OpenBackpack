using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(BackpackWheel), nameof(BackpackWheel.Update))]
public class BackpackWheel_Update_Patch
{
	public static void Prefix(BackpackWheel __instance, ref bool __runOriginal)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		// close if the pause button was pressed
		if (Character.localCharacter.input.pauseWasPressed) return;

		// disable automatic closing
		__runOriginal = false;
	}
}
