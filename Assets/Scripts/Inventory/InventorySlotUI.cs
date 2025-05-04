using UnityEngine;
using UnityEngine.UI;
using Project.Inventory;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    /// <summary>
    /// Sets the image in the inventory UI.
    /// </summary>
    /// <param name="icon">Sprite to be shown in the inventory.</param>
    public void SetIcon(Sprite icon)
    {
        iconImage.sprite = icon;
        iconImage.enabled = icon != null;
    }
}
