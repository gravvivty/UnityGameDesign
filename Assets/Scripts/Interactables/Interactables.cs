using UnityEngine;
using Project.Helper;

namespace Project.Interactable
{
    public abstract class Interactables : MonoBehaviour
    {
        [SerializeField] private MouseRaycast mouseRaycast;
        private SpriteOutline spriteOutline;
        private bool isHighlighted = false;

        protected virtual void Start()
        {
            spriteOutline = gameObject.AddComponent<SpriteOutline>();
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

            if (Input.GetMouseButtonDown(0) && shouldHighlight)
            {
                Interact();
            }
        }

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