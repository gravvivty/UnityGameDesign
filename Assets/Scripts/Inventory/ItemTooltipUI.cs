using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TooltipUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public GameObject tooltipObject;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = tooltipObject.GetComponent<CanvasGroup>();

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