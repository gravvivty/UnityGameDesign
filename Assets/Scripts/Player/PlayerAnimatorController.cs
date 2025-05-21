using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector3 lastPosition;
    private float movementThreshold = 0.01f; // Avoid false movement triggers

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 delta = currentPosition - lastPosition;

        float speed = delta.magnitude / Time.deltaTime;

        // Optional: prevent jitter by zeroing out tiny values
        if (speed < movementThreshold)
            speed = 0f;

        animator.SetFloat("Speed", speed);

        // Flip sprite on horizontal movement
        if (delta.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (delta.x < -0.01f)
            spriteRenderer.flipX = true;

        lastPosition = currentPosition;
    }
}