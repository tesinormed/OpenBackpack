using HarmonyLib;

namespace industries._5505.tesinormed.OpenBackpack.Patches;

[HarmonyPatch(typeof(BackpackWheel), nameof(BackpackWheel.InitWheel))]
public class BackpackWheel_InitWheel_Patch
{
	public static void Postfix(ref BackpackWheel __instance)
	{
		if (!Plugin.IsModifiedBackpackWheel) return;

		foreach (var backpackWheelSlice in __instance.slices)
		{
			// ignore currently held backpack for button interaction
			backpackWheelSlice.button.interactable = backpackWheelSlice.hasItem;

			// add onClick pickup
			backpackWheelSlice.button.onClick.AddListener(() =>
			{
				if (backpackWheelSlice.backpack.GetVisuals().TryGetSpawnedItem(backpackWheelSlice.backpackSlot, out var item)) item.Interact(Character.localCharacter);
				GUIManager.instance.CloseBackpackWheel();
			});
		}

		// disable the pickup backpack slice
		__instance.slices[0].gameObject.SetActive(false);

		// disable the currently held item image
		__instance.currentlyHeldItem.enabled = false;
	}
}
