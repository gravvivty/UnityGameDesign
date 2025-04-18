using UnityEngine;
using Project.Helper;
using Unity.VisualScripting;

namespace Project.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MouseRaycast mouseRaycast;
        [SerializeField] private float moveSpeed = 2f;

        private bool isMoving = false;
        private Vector2 targetPosition;

        // Update is called once per frame
        void Update()
        {
            HandleMovement();
        }


        /// <summary>
        /// Handles the movement of the player if we are clicking on "Ground".
        /// It will continously move the player towards the click position until the player reaches it.
        /// </summary>
        private void HandleMovement()
        {
            GameObject gameObjectHit = mouseRaycast.GetGameObject();
            bool isGround = gameObjectHit != null && gameObjectHit.CompareTag("Ground");

            if (Input.GetMouseButtonDown(0) && isGround)
            {
                targetPosition = mouseRaycast.GetMousePosition();
                isMoving = true;
            }

            if (isMoving)
            {
                Vector2 currentPosition = transform.position;
                transform.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);

                // Stop moving when we reach the target
                if ((Vector2)transform.position == targetPosition)
                {
                    isMoving = false;
                }
            }
        }
    }
}
