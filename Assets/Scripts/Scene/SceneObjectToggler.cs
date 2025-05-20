using System.Collections.Generic;
using Project.Inventory;
using UnityEngine;

namespace Project.Scene.SceneObjectToggler
{
    public class SceneObjectToggler : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToToggle;
        [SerializeField] private ItemData[] requiredItems;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // if (InventoryManager.Instance.AddingItem == false)
            //     return;

            CheckItem();
        }

        private void CheckItem()
        {
            // Check if the player has the required items in their inventory
            foreach (ItemData item in requiredItems)
            {
                if (!InventoryManager.Instance.HasItemWithID(item.itemID))
                {
                    //Debug.Log($"Player does not have the required item: {item.itemName}");
                    return;
                }
            }

            // Toggle the objects based on whether the player has all required items
            foreach (GameObject obj in objectsToToggle)
            {
                Debug.Log($"Toggling object: {obj.name}");
                obj.SetActive(!obj.activeSelf);
                this.gameObject.SetActive(false); // Disable this object after toggling
            }
        }
    }
}
