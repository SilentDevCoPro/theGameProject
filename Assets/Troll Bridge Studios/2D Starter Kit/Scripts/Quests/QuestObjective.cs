using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjective : MonoBehaviour {

    public string questObjective;
    public int amount;
    public int questIDToComplete;
    public int questIDToAccept;

    private void Awake()
    {
        if(questObjective != null && amount > 0)
            QuestManager.questManager.AddQuestItem(questObjective, amount);

        if (questIDToComplete > 0 && questIDToAccept > 0 )
        {
            QuestManager.questManager.CompleteQuest(questIDToComplete);
            QuestManager.questManager.AcceptQuest(questIDToAccept);
        }
    }
}
