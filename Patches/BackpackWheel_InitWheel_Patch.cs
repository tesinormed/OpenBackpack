using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(BackpackWheel), nameof(BackpackWheel.InitWheel))]
internal static class BackpackWheel_InitWheel_Patch
{
	public static void Postfix(BackpackWheel __instance)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		foreach (var backpackWheelSlice in __instance.slices)
			// when the slice is clicked (and interactable), pickup the item
			backpackWheelSlice.button.onClick.AddListener(() =>
			{
				Plugin.Logger.LogInfo("picking up item from backpack");
				if (backpackWheelSlice.backpack.GetVisuals().TryGetSpawnedItem(backpackWheelSlice.backpackSlot, out var item)) item.Interact(Character.localCharacter);
				Plugin.Logger.LogInfo("closing modified backpack wheel");
				GUIManager.instance.CloseBackpackWheel();
			});

		// remove the wear backpack slice
		__instance.slices[0].gameObject.SetActive(false);

		// disable the currently held item image
		__instance.currentlyHeldItem.enabled = false;
	}
}
