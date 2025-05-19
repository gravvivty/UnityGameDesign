using Project.Inventory;
using UnityEngine;

namespace Project.Interactable.InSceneInteract
{
    public class WellReceiver : ItemReceiver
    {
        public override bool TryUseItem(ItemData draggedItem)
        {
            // Check for a valid combination
            if (draggedItem.CanCombine(itemRepresentation.itemID))
            {
                ItemData result = draggedItem.GetCombinationResult(itemRepresentation.itemID);
                Debug.Log($"Combined {draggedItem.itemName} with {itemRepresentation.itemName} to get {result.itemName}");
                
                // CUSTOM LOGIC -----
                if (spriteRenderer != null && itemRepresentation.itemName == "Well")
                {
                    itemRepresentation = result;
                    spriteRenderer.sprite = itemRepresentation.icon;
                }
                if (spriteRenderer != null && itemRepresentation.itemName == "WellRope")
                {
                    itemRepresentation = result;
                    spriteRenderer.sprite = itemRepresentation.icon;
                    // Do something else idk, add something to  the inventory or sum shit
                }

                return true;
                // CUSTOM LOGIC ----
            }

            Debug.Log("Can't use this item on the Well.");
            return false;
        }
    }
}