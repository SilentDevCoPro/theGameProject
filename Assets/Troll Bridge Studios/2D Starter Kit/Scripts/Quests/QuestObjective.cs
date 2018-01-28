using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrollBridge
{
    public class QuestObjective : MonoBehaviour
    {

        public string questObjective;
        public int amount = 0;
        public int questIDToComplete = 0;
        public int questIDToAccept = 0;

        private void Awake()
        {
            if (questObjective != null && amount > 0)
                QuestManager.questManager.AddQuestItem(questObjective, amount);

            if (questIDToComplete > 0 && questIDToAccept > 0)
            {
                for (int i = 0; i < QuestManager.questManager.currentQuestList.Count; i++)
                {
                    if (QuestManager.questManager.currentQuestList[i].questObjective == questObjective)
                    {
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
}
