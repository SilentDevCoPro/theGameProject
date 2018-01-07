using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveStarter : MonoBehaviour {

    public string questObjective;
    public int amount;
    public int questIDToComplete;
    public int questIDToAccept;

    private void Awake()
    {
        QuestManager.questManager.AddQuestItem(questObjective, amount);
        QuestManager.questManager.CompleteQuest(questIDToComplete);
        QuestManager.questManager.AcceptQuest(questIDToAccept);
    }
}
