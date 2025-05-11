using UnityEngine;
using TMPro;

public class TooltipUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public GameObject tooltipObject;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = tooltipObject.GetComponent<CanvasGroup>();

        // Make sure tooltipObject is active so it can receive updates and pointer events
        tooltipObject.SetActive(true);
    }

    private void Update()
    {
        if (canvasGroup != null)
        {
            tooltipObject.transform.position = Input.mousePosition + new Vector3(0f, 0f, 0f);
        }
    }

    public void ShowTooltip(string name, string description)
    {
        nameText.text = name;
        descriptionText.text = description;
        Debug.Log("CHANGE TOOLTIP");
    }
}