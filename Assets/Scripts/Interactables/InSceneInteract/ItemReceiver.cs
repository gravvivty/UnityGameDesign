using System;
using Project.Interactable;
using UnityEngine;
using Project.Inventory;

public class ItemReceiver : Interactables
{
    public ItemData itemRepresentation;  
    public SpriteRenderer spriteRenderer;  // Optional: for sprite swap
    // Can add more variables every itemreceiver should need but cant think of more atm

    protected void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (itemRepresentation != null && spriteRenderer != null)
            spriteRenderer.sprite = itemRepresentation.icon;
    }

    /// <summary>
    /// Called when an inventory item is dropped onto this object.
    /// </summary>
    public virtual bool TryUseItem(ItemData draggedItem)
    {
        Debug.Log($"Trying to use {draggedItem.itemName} on {gameObject.name}");

        // Check if this object expects this item
        if (draggedItem.itemID == itemRepresentation?.itemID)
        {
            // Example action: DEBUG msg
            Debug.Log($"Correct item used on {gameObject.name}!");

            return true;
        }

        Debug.Log($"Wrong item used on {gameObject.name}.");
        return false;
    }

    protected override void Interact()
    {
        
    }
}