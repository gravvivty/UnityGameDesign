using UnityEngine;

public class DepthScaler : MonoBehaviour
{
    public float minY = -7f;     // Foreground
    public float maxY = 7f;      // Background
    public float minScale = 1f;  // Scale when closest
    public float maxScale = 0.3f; // Scale when furthest

    public GameObject player;
    private Vector3 originalScale;

    void Start()
    {
        if (player != null)
        {
            originalScale = player.transform.localScale;
        }
        else
        {
            Debug.LogWarning("Player reference not set in DepthScaler.");
        }
    }

    void Update()
    {
        if (player == null) return;

        float t = Mathf.InverseLerp(minY, maxY, player.transform.position.y);
        float scale = Mathf.Lerp(minScale, maxScale, t);
        player.transform.localScale = originalScale * scale;
    }
}