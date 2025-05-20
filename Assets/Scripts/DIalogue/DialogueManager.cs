using UnityEngine;
using Project.Dialogue.Data;
using System.Collections.Generic;

namespace Project.Dialogue
{
    /// <summary>
    /// Class to manage the dialogue system, including starting dialogues, making choices, and checking conditions.
    /// </summary>
    public class DialogueManager : MonoBehaviour
    {
        private static DialogueManager instance;
        public static DialogueManager Instance => instance;

        [SerializeField] private DialogueUI dialogueUI;
        private DialogueData currentDialogueData;
        private DialogueLine currentDialogue;
        private Vector3 currentPosition;
        private GameObject currentDialogueUIObject;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        public void StartDialogue(DialogueData dialogueData, string dialogueID, Vector3 position)
        {
            if (currentDialogueUIObject != null)
            {
                Destroy(currentDialogueUIObject);
            }

            if (dialogueData == null || dialogueID == "") return;

            Vector3 dialogUIPosition = position + new Vector3(3.5f, 3.5f, 0);
            currentPosition = position;
            var dialogeUIObject = Instantiate(dialogueUI, dialogUIPosition, Quaternion.identity);
            currentDialogueUIObject = dialogeUIObject.gameObject;
            currentDialogueData = dialogueData;
            var dialogueLine = dialogueData.GetDialogueLine(dialogueID);

            if (dialogueLine != null)
            {
                currentDialogue = dialogueLine;
                dialogeUIObject.DisplayDialogue(dialogueLine);
            }
        }

        public void EndDialogue()
        {
            if (currentDialogueUIObject != null)
            {
                Destroy(currentDialogueUIObject);
                currentDialogueUIObject = null;
            }
            currentDialogueData = null;
            currentDialogue = null;
        }

        public void MakeChoice(int choiceIndex)
        {
            choiceIndex = Mathf.Clamp(choiceIndex, 0, currentDialogue.Choices.Count - 1);
            Debug.Log($"Making choice {choiceIndex} for dialogue {currentDialogue.DialogueID}");
            if (currentDialogue == null) return;
            var choice = currentDialogue.Choices[choiceIndex];
            if (CheckConditions(choice.Conditions))
            {
                GiveRewards(currentDialogue.Rewards);
                StartDialogue(currentDialogueData, choice.NextDialogueID, currentPosition);
            }
        }

        private bool CheckConditions(List<DialogueCondition> conditions)
        {
            Debug.Log($"Checking conditions for dialogue {currentDialogue.DialogueID}");
            if (conditions == null) return true;

            foreach (var condition in conditions)
            {
                switch (condition.Type)
                {
                    case ConditionType.HasItem:
                        break;
                }
            }
            return true;
        }

        private void GiveRewards(List<DialogueReward> rewards)
        {
            if (rewards == null) return;

            foreach (var reward in rewards)
            {
                switch (reward.Type)
                {
                    case RewardType.Item:
                        Debug.Log($"Giving rewards {reward.ItemID} for dialogue {currentDialogue.DialogueID}");
                        break;
                }
            }
        }
    }
}