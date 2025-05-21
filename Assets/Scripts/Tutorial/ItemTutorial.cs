using Project.Dialogue;
using Project.Inventory;
using UnityEngine;

namespace Project.Tutorial
{
    /// <summary>
    /// Class responsible managing the tutorial for items.
    /// </summary>
    public class ItemTutorial : MonoBehaviour
    {
        [SerializeField] private ItemData itemData;
        [SerializeField] private TutorialUI tutorialBoxUI;
        [SerializeField][TextArea] private string dialogueToShow;
        [SerializeField] private float delay = 5f;
        private float timer = 0f;

        // Update is called once per frame
        void Update()
        {
            if (InventoryManager.Instance.HasItemWithID(itemData.itemID))
            {
                // Check if the player has the item
                if (tutorialBoxUI != null && !string.IsNullOrEmpty(dialogueToShow))
                {
                    tutorialBoxUI.SetTutorialText(dialogueToShow);
                }

                // Start the timer
                timer += Time.deltaTime;
                if (timer >= delay || Input.GetMouseButtonDown(0))
                {
                    // Destroy this GameObject after the delay
                    Destroy(gameObject);
                }
            }
            else
            {
                // Hide the tutorial box if the item is not in the inventory
                tutorialBoxUI.gameObject.SetActive(false);
            }
        }
    }
}
