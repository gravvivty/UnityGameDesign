using UnityEngine;
using UnityEngine.UI;
using Project.Dialogue.Data;
using System.Collections.Generic;
using TMPro;

namespace Project.Dialogue
{
    /// <summary>
    /// Class to manage the dialogue UI and display dialogue lines and choices.
    /// </summary>
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Transform choicesContainer;
        [SerializeField] private GameObject choiceButtonPrefab;

        public void DisplayDialogue(DialogueLine dialogue)
        {
            dialogueText.text = dialogue.Text;
            DisplayChoices(dialogue.Choices);
        }

        private void DisplayChoices(List<DialogueChoice> choices)
        {
            // Clear existing choices
            foreach (Transform child in choicesContainer)
            {
                Destroy(child.gameObject);
            }

            // Create new choice buttons
            for (int i = 0; i < choices.Count; i++)
            {
                var choice = choices[i];
                Vector3 buttonPosition = choicesContainer.position - new Vector3(0, i * 0.75f, 0);
                var buttonObj = Instantiate(choiceButtonPrefab, buttonPosition, Quaternion.identity, choicesContainer);
                var button = buttonObj.GetComponentInChildren<Canvas>().GetComponentInChildren<Button>();
                var text = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
                text.text = choice.Text;

                Debug.Log($"Choice {i}: {choice.Text}");
                int choiceIndex = i; // Capture the current index for the listener
                button.onClick.AddListener(() => DialogueManager.Instance.MakeChoice(choiceIndex));
            }
        }
    }
}