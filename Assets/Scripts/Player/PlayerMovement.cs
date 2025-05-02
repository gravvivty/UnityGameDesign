using UnityEngine;
using Project.Helper;
using Project.Interactable;
using Unity.VisualScripting;

namespace Project.Player
{
    /// <summary>
    /// Class responsible for handling the player movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private MouseRaycast mouseRaycast;
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float minDistanceToInteractable = 5f;

        private bool isMoving = false;
        private Vector2 targetPosition;
        private GameObject currentInteractable;

        // Update is called once per frame
        void Update()
        {
            HandleMovement();
            CheckSpriteLayer();
        }


        /// <summary>
        /// Handles the movement of the player if we are clicking on "Ground".
        /// It will continously move the player towards the click position until the player reaches it.
        /// Unless the player clicks on an interactable object, in which case it will stop moving once close enough.
        /// </summary>
        private void HandleMovement()
        {
            GameObject gameObjectHit = mouseRaycast.GetGameObject();
            bool isGround = gameObjectHit != null && gameObjectHit.CompareTag("Ground");

            if (Input.GetMouseButtonDown(0))
            {
                if (isGround)
                {
                    Debug.Log("Clicked on ground: " + gameObjectHit.name);
                    targetPosition = mouseRaycast.GetMousePosition();
                    currentInteractable = null;
                    isMoving = true;
                }
                else if (gameObjectHit != null && gameObjectHit.GetComponent<Interactables>() != null)
                {
                    targetPosition = (Vector2)gameObjectHit.transform.position;
                    currentInteractable = gameObjectHit;
                    isMoving = true;
                }
            }

            if (isMoving)
            {
                Vector2 currentPosition = transform.position;
                transform.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);

                // Check if we should stop based on the type of target
                if (currentInteractable != null)
                {
                    float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
                    if (distanceToTarget <= minDistanceToInteractable)
                    {
                        isMoving = false;
                    }
                }
                else if ((Vector2)transform.position == targetPosition)
                {
                    isMoving = false;
                }
            }
        }

        /// <summary>
        /// Checks the Y position of the player and sets the sorting layer accordingly.
        /// This is used to ensure that the player sprite is rendered above or below other sprites.
        /// </summary>
        private void CheckSpriteLayer()
        {
            if (spriteRenderer != null)
            {
                // Set the sorting layer based on the Y position of the player
                if (transform.position.y < 0)
                {
                    spriteRenderer.sortingLayerID = SortingLayer.NameToID("PlayerAbove");
                }
                else
                {
                    spriteRenderer.sortingLayerID = SortingLayer.NameToID("PlayerBelow");
                }
            }
        }
    }
}
