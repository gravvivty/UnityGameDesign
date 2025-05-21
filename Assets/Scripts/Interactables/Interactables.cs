using UnityEngine;
using Project.Helper;
using Project.Inventory;
using Project.Player;

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
        private GameObject hoveredObject;

        protected virtual void Start()
        {
            spriteOutline = gameObject.AddComponent<SpriteOutline>();
            mouseRaycast = GameObject.FindGameObjectWithTag("Mouse").GetComponent<MouseRaycast>();
        }

        protected virtual void Update()
        {
            hoveredObject = mouseRaycast.GetGameObject();
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
                PlayerMovement player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
                if (player != null)
                {
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    if (distance <= player.GetMinDistanceToInteractable())
                    {
                        // Stop waiting for player to get close and start interaction
                        waitingForPlayerToGetClose = false;
                        Interact();
                        player.ResetMinDistanceToInteractable();
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
            
            if (shouldHighlight && hoveredObject.CompareTag("Door"))
            {
                CursorManager.Instance.SetDoorCursor();
            } else if (shouldHighlight && hoveredObject.CompareTag("NPC"))
            {
                CursorManager.Instance.SetDialogueCursor();
            } else if (shouldHighlight && hoveredObject.CompareTag("Item"))
            {
                CursorManager.Instance.SetGrabCursor();
            } else if (shouldHighlight && hoveredObject.CompareTag("Put"))
            {
                CursorManager.Instance.SetPutCursor();
            }
            else
            {
                CursorManager.Instance.SetNormalCursor();
            }
            
            hoveredObject = null;
        }

        protected abstract void Interact();
    }
}