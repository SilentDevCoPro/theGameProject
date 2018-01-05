using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuest : MonoBehaviour {

    public string objective;
    public int amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            //Adds the quest item to complete the phase
            QuestManager.questManager.AddQuestItem(objective, amount);

            //Testing Perposes
            QuestManager.questManager.CompleteQuest(1);
            QuestManager.questManager.AcceptQuest(2);

            //Set quest object markers
            QuestObject[] currentQuestObjects = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
            foreach (QuestObject qobj in currentQuestObjects)
            {
                qobj.SetQuestMarker();
            }
        }
    }
}
