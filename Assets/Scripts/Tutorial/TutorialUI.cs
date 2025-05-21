using TMPro;
using UnityEngine;

namespace Project.Tutorial
{
    /// <summary>
    /// Class responsible for displaying the tutorial UI.
    /// </summary>
    public class TutorialUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tutorialText;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetTutorialText(string text)
        {
            tutorialText.text = text;
        }
    }
}
