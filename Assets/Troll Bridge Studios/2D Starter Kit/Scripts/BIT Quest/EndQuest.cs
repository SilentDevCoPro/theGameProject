using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuest : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        QuestManager.questManager.AddQuestItem("Look around the town", 1);
        QuestManager.questManager.CompleteQuest(1);
        QuestManager.questManager.AcceptQuest(2);
        QuestObject[] currentQuestObjects = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject qobj in currentQuestObjects)
        {
            qobj.SetQuestMarker();
        }
    }
}
