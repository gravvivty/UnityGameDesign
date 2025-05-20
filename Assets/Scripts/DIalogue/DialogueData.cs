using System.Collections.Generic;
using UnityEngine;


namespace Project.Dialogue.Data
{
    /// <summary>
    /// ScriptableObject to hold a list of dialogue lines.
    /// </summary>
    [CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
    public class DialogueData : ScriptableObject
    {
        public List<DialogueLine> dialogueLines = new List<DialogueLine>();

        // Helper method to get a dialogue line by ID
        public DialogueLine GetDialogueLine(string id)
        {
            return dialogueLines.Find(line => line.DialogueID == id);
        }
    }
}
