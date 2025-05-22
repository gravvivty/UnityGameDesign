using System.Collections.Generic;
using Project.Inventory;
using UnityEngine;

namespace Project.Scene.SceneObjectToggler
{
    public class SceneObjectToggler : MonoBehaviour
    {
        [SerializeField] private bool mustHaveAllItems = false;
        [SerializeField] private GameObject[] objectsToToggle;
        [SerializeField] private ItemData[] requiredItems;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            CheckItem();
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
            // Check if the player has the required items
            if (!HasRequiredItems())
            {
                return; // Exit early if required items are missing
            }

            // Toggle the objects and disable this object
            ToggleObjects();
        }

        private bool HasRequiredItems()
        {
            // Check if the player has all the required items or at least one, based on the flag 'mustHaveAllItems'
            foreach (ItemData item in requiredItems)
            {
                bool hasItem = InventoryManager.Instance.HasItemWithID(item.itemID);

                if (mustHaveAllItems && !hasItem)
                {
                    return false; // Player doesn't have all items, exit early
                }

                if (!mustHaveAllItems && hasItem)
                {
                    return true; // Player has at least one required item, exit early
                }
            }

            // If we are here, it means we are in the "mustHaveAllItems" case and all items were found
            return mustHaveAllItems;
        }

        private void ToggleObjects()
        {
            foreach (GameObject obj in objectsToToggle)
            {
                if (obj == null)
                {
                    continue;
                }
                Debug.Log($"Toggling object: {obj.name}");
                obj.SetActive(!obj.activeSelf);
            }
            this.gameObject.SetActive(false);
        }

    }
}
