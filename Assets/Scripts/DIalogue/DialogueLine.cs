using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Dialogue.Data
{
    /// <summary>
    /// General class to hold the basic structure of a dialogue line.
    /// /summary>
    [Serializable]
    public class DialogueLine
    {
        public string DialogueID;
        public string Text;
        public List<DialogueChoice> Choices;
        public List<DialogueCondition> Conditions;
        public List<DialogueReward> Rewards;
    }

    /// <summary>
    /// Class to hold the structure of a dialogue choice.
    /// /summary>
    [Serializable]
    public class DialogueChoice
    {
        public string Text;
        public string NextDialogueID;
        public List<DialogueCondition> Conditions;
    }

    /// <summary>
    /// Class to hold the structure of a dialogue condition.
    /// /summary>
    [Serializable]
    public class DialogueCondition
    {
        public ConditionType Type;
        public string ItemID;
        public bool Required;
    }

    /// <summary>
    /// Class to hold the structure of a dialogue reward.
    /// /summary>
    [Serializable]
    public class DialogueReward
    {
        public RewardType Type;
        public string ItemID;
        public int Amount;
    }

    public enum ConditionType
    {
        HasItem,
        QuestComplete
    }

    public enum RewardType
    {
        Item,
        Quest
    }
}