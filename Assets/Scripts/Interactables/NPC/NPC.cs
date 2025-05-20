using Unity.VisualScripting;
using UnityEngine;
using Project.Dialogue;
using Project.Dialogue.Data;

namespace Project.Interactable.NPC
{
    public class NPC : Interactables
    {
        [SerializeField] private DialogueData dialogueData;
        [SerializeField] private string initialDialogueID;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            // Check if the player is close enough to interact with the NPC
            if (!IsPlayerClose())
            {
                DialogueManager.Instance.EndDialogue();
            }
        }

        protected override void Interact()
        {
            if (dialogueData == null)
            {
                Debug.LogError($"No dialogue data assigned to NPC: {gameObject.name}");
                return;
            }

            DialogueManager.Instance.StartDialogue(dialogueData, initialDialogueID, transform.position);
        }

        private bool IsPlayerClose()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                return distance <= 5.0f;
            }
            else
            {
                return false;
            }
        }
    }
}
