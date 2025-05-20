using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TooltipUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public GameObject tooltipObject;
    private CanvasGroup canvasGroup;
    private bool showTooltip = false;

    private void Start()
    {
        canvasGroup = tooltipObject.GetComponent<CanvasGroup>();

        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false;
        }
        
        // Make sure tooltipObject is active so it can receive updates and pointer events
        tooltipObject.SetActive(true);
        tooltipObject.GetComponent<Image>().enabled = false;
        foreach (Transform child in tooltipObject.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (canvasGroup != null)
        {
            Vector2 cursorPosition = Input.mousePosition;
            RectTransform tooltipRect = tooltipObject.GetComponent<RectTransform>();

            // Offset to the right and slightly upward
            Vector2 offset = new Vector2(tooltipRect.rect.width * 0.6f, tooltipRect.rect.height * 0.1f);
            tooltipObject.transform.position = cursorPosition + offset;

            // to bypass the 1 frame flicker tooltip at original pos, doesnt work tho
            if (showTooltip)
            {
                tooltipObject.GetComponent<Image>().enabled = true;
                foreach (Transform child in tooltipObject.transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    public void ChangeTooltip(string name, string description)
    {
        nameText.text = name;
        descriptionText.text = description;
        Debug.Log("CHANGE TOOLTIP");
    }

    public void SetShow(bool show)
    {
        showTooltip = show;
    }
}