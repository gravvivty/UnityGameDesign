using UnityEngine;
using UnityEngine.UI;
using Project.Inventory;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventorySlotPrefab;  // Reference to the Inventory Slot prefab
    [SerializeField] private Transform inventoryGrid;  // The grid where inventory slots are placed
    [SerializeField] private GameObject inventoryPanel;
    private bool isOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Change key or hook up a UI button
        {
            ToggleInventory();
        }
    }
    
    public void UpdateInventoryUI()
    {
        // Clear the grid first
        foreach (Transform child in inventoryGrid)
        {
            Destroy(child.gameObject);
        }

        // Iterate through the items in the InventoryManager
        foreach (ItemData item in InventoryManager.Instance.GetAllItems())
        {
            // Create a new inventory slot for each item in the inventory
            GameObject inventorySlot = Instantiate(inventorySlotPrefab, inventoryGrid);

            // Get the InventorySlotUI component from the new slot
            InventorySlotUI inventorySlotUI = inventorySlot.GetComponent<InventorySlotUI>();

            // Assign the item's icon to the InventorySlotUI
            inventorySlotUI.SetIcon(item.icon);
        }
    }
    
    public void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        if (isOpen)
        {
            UpdateInventoryUI();
        }
    }
}
