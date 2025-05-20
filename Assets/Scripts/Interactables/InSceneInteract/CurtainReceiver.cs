using Project.Inventory;
using UnityEngine;

namespace Project.Interactable.InSceneInteract
{
    public class CurtainReceiver : ItemReceiver
    {
        public override bool TryUseItem(ItemData draggedItem)
        {
            // Check for a valid combination
            if (draggedItem.CanCombine(itemRepresentation.itemID))
            {
                ItemData result = draggedItem.GetCombinationResult(itemRepresentation.itemID);
                Debug.Log($"Combined {draggedItem.itemName} with {itemRepresentation.itemName} to get {result.itemName}");
                
                // CUSTOM LOGIC -----
                if (spriteRenderer != null && draggedItem.itemID == 56)
                {
                    itemRepresentation = result;
                    spriteRenderer.sprite = itemRepresentation.icon;

                    Debug.Log("IT BUUUURNS!!!");
                }

                return true;
                // CUSTOM LOGIC ----
            }

            Debug.Log("Can't use this item on the Curtain.");
            return false;
        }
    }
}