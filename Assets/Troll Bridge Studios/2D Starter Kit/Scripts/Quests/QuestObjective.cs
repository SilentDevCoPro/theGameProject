using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjective : MonoBehaviour {

    public string questObjective;
    public int amount = 0;
    public int questIDToComplete = 0;
    public int questIDToAccept = 0;

    private void Awake()
    {
        if(questObjective != null && amount > 0)
            QuestManager.questManager.AddQuestItem(questObjective, amount);

        if (questIDToComplete > 0 && questIDToAccept > 0)
        {
            Debug.Log("STEP 1 COMPLETED");
            for (int i = 0; i < QuestManager.questManager.currentQuestList.Count; i++)
            {
                Debug.Log("Current Quest Count: " + i);
                if (QuestManager.questManager.currentQuestList[i].questObjective == questObjective)
                {
                    Debug.Log("Current: " + QuestManager.questManager.currentQuestList[i].questObjectivesCount
                        + "/Objective: " + QuestManager.questManager.currentQuestList[i].questObjectiveRequirement);

                    if (QuestManager.questManager.currentQuestList[i].questObjectivesCount == QuestManager.questManager.currentQuestList[i].questObjectiveRequirement)
                    {
                        QuestManager.questManager.CompleteQuest(questIDToComplete);
                        QuestManager.questManager.AcceptQuest(questIDToAccept);
                    }
                }
            }
        }
    }
}
