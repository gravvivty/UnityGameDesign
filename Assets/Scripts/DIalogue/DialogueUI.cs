using UnityEngine;
using UnityEngine.UI;
using Project.Dialogue.Data;
using System.Collections.Generic;
using TMPro;
using Project.Inventory;

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
            if (CheckConditions(dialogue.Conditions) == false)
            {
                Debug.Log("Dialogue conditions not met, skipping dialogue.");
                dialogueText.text = "I cannot speak to you yet.";
                return;
            }
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
                if (choices[i].Conditions != null && choices[i].Conditions.Count > 0)
                {
                    if (!CheckChoiceConditions(choices[i])) continue; // Skip this choice if conditions are not met
                }

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

        public bool CheckChoiceConditions(DialogueChoice dialogueChoice)
        {
            // Check conditions here and skip if not met
            bool conditionsMet = true;
            foreach (var condition in dialogueChoice.Conditions)
            {
                switch (condition.Type)
                {
                    case ConditionType.HasItem:
                        // Check if the player has the item
                        if (!InventoryManager.Instance.HasItemWithID(condition.ItemID))
                        {
                            conditionsMet = false;
                        }
                        break;
                }
            }

            return conditionsMet;
        }

        public bool CheckConditions(List<DialogueCondition> conditions)
        {
            // Check conditions here and skip if not met
            bool conditionsMet = true;
            foreach (var condition in conditions)
            {
                switch (condition.Type)
                {
                    case ConditionType.HasItem:
                        // Check if the player has the item
                        if (!InventoryManager.Instance.HasItemWithID(condition.ItemID))
                        {
                            conditionsMet = false;
                        }
                        break;
                }
            }

            return conditionsMet;
        }
    }
}