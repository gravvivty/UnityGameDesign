using UnityEngine;
using Project.Helper;
using Project.Inventory;

namespace Project.Interactable
{
    /// <summary>
    /// Base class for all interactable objects in the game.
    /// </summary>
    public abstract class Interactables : MonoBehaviour
    {
        private MouseRaycast mouseRaycast;
        private SpriteOutline spriteOutline;
        private bool isHighlighted = false;
        private bool waitingForPlayerToGetClose = false;
        private float minInteractionDistance = 5f;

        protected virtual void Start()
        {
            spriteOutline = gameObject.AddComponent<SpriteOutline>();
            mouseRaycast = GameObject.FindGameObjectWithTag("Mouse").GetComponent<MouseRaycast>();
        }

        protected virtual void Update()
        {
            GameObject hoveredObject = mouseRaycast.GetGameObject();
            bool shouldHighlight = false;

            if (hoveredObject != null)
            {
                // Check if the hovered object is this interactable
                shouldHighlight = hoveredObject == gameObject;
            }

            // Only update highlight if the state needs to change
            if (shouldHighlight != isHighlighted)
            {
                HandleHoverEffect(shouldHighlight);
            }

            // Check if we're waiting for player to get close
            if (waitingForPlayerToGetClose)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    if (distance <= minInteractionDistance)
                    {
                        waitingForPlayerToGetClose = false;
                        Interact();
                    }
                }
            }
            // Only start interaction process when clicked
            else if (Input.GetMouseButtonDown(0) && shouldHighlight)
            {
                waitingForPlayerToGetClose = true;
            }
        }

        /// <summary>
        /// Handles the hover effect by showing or hiding the outline.
        /// </summary>
        private void HandleHoverEffect(bool shouldHighlight)
        {
            if (spriteOutline != null)
            {
                spriteOutline.ShowOutline(shouldHighlight);
                isHighlighted = shouldHighlight;
            }
        }

        protected abstract void Interact();
    }
}