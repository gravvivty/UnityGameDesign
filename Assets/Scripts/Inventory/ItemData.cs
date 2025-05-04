using UnityEngine;

namespace Project.Inventory
{
    /// <summary>
    /// Represents the data for a single inventory item.
    /// This includes the item's name, unique ID, description, and icon.
    /// </summary>
    [CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Item")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public string itemID;
        [TextArea] public string description;
        public Sprite icon;
    }
}