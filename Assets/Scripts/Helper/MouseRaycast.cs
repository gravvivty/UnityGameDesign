using UnityEngine;

namespace Project.Helper
{
    /// <summary>
    /// This class is used to raycast from the mouse position to detect all sorts of stuff.
    /// It can be expanded to include functions needed
    /// </summary>
    public class MouseRaycast : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;


        /// <summary>
        /// Returns the game object that is hit by the raycast from the mouse position.
        /// </summary>
        public GameObject GetGameObject()
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                return hit.collider.gameObject;
            }
            return null;
        }

        /// <summary>
        /// Returns the mouse position in world coordinates.
        /// </summary>
        public Vector2 GetMousePosition()
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            return mousePosition;
        }
    }
}