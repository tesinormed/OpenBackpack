using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(Item), nameof(Item.Awake))]
internal static class Item_Awake_Patch
{
	public static void Postfix(Item __instance)
	{
		if (__instance is not Backpack) return;

		// add the UI prompt
		__instance.UIData.mainInteractPrompt = "OPEN";
		__instance.UIData.hasMainInteract = true;

		// when the "use primary" button is pressed, open the backpack wheel
		var item = __instance;
		__instance.OnPrimaryStarted += () =>
		{
			Plugin.Logger.LogInfo("opening modified backpack wheel");
			Plugin.IsModifiedBackpackWheel = true;
			GUIManager.instance.OpenBackpackWheel(BackpackReference.GetFromBackpackItem(item));
		};
	}
}
