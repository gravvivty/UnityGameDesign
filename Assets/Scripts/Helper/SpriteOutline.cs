using UnityEngine;

namespace Project.Helper
{
    public class SpriteOutline : MonoBehaviour
    {
        [SerializeField] private Color outlineColor = Color.red;
        [SerializeField] private float outlineSize = 1.1f;

        private SpriteRenderer outlineRenderer;
        private SpriteRenderer mainRenderer;

        private void Start()
        {
            // Create child object for outline
            GameObject outlineObject = new GameObject("Outline");
            outlineObject.transform.parent = transform;
            outlineObject.transform.localPosition = Vector3.zero;

            // Add and setup outline sprite renderer
            outlineRenderer = outlineObject.AddComponent<SpriteRenderer>();
            mainRenderer = GetComponent<SpriteRenderer>();

            // Copy sprite and sorting properties
            outlineRenderer.sprite = mainRenderer.sprite;
            outlineRenderer.sortingLayerID = mainRenderer.sortingLayerID;
            outlineRenderer.sortingOrder = mainRenderer.sortingOrder - 1;

            // Set initial state
            outlineRenderer.gameObject.SetActive(false);
        }

        public void ShowOutline(bool show)
        {
            if (outlineRenderer != null)
            {
                outlineRenderer.gameObject.SetActive(show);
                if (show)
                {
                    outlineRenderer.transform.localScale = Vector3.one * outlineSize;
                    outlineRenderer.color = outlineColor;
                }
            }
        }
    }
}