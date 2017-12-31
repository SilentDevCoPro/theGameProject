using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static QuestManager questManager;

    public List<Quest> questList = new List<Quest>();
    public List<Quest> currentQuestList = new List<Quest>();

    

    void Awake() {
        if (questManager == null)
            questManager = this;
        else if (questManager != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    //ADD ITEMS
    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for (int i = 0; i < currentQuestList.Count; i++) {
            if (currentQuestList[i].questObjective == questObjective &&
                currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].questObjectivesCount += itemAmount;
            }

            if (currentQuestList[i].questObjectivesCount >= currentQuestList[i].questObjectiveRequirement
                && currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuestList[i].progress = Quest.QuestProgress.COMPLETE;
            }
        }
    }
    //REMOVE ITEMS - User inventory system

    //ACCEPT QUEST
    public void AcceptQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++) {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVALIABLE)
            {
                currentQuestList.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;
            }
        }
    }

    //COMPLETED
    public void CompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.COMPLETE)
            {
                currentQuestList[i].progress = Quest.QuestProgress.DONE;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
        
    }
    //BOOLS
    public bool RequestAvaliableQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++) {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVALIABLE)
                return true;
        }
        return false;
    }

    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED)
                return true;
        }
        return false;
    }

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.COMPLETE)
                return true;
        }
        return false;
    }

}
