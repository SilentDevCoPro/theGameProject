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

    public void QuestRequest(QuestObject NPCQuestObject)
    {
        //Checking for avaliable quests
        if (NPCQuestObject.avaliableQuestIDs.Count > 0)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                for (int j = 0; j < NPCQuestObject.avaliableQuestIDs.Count; j++)
                {
                    if (questList[i].id == NPCQuestObject.avaliableQuestIDs[j] &&
                        questList[i].progress == Quest.QuestProgress.AVALIABLE)
                    {
                        Debug.Log("Quest ID: " + NPCQuestObject.avaliableQuestIDs[j] + " " +
                            questList[i].progress);
                        //TESTING
                        //AcceptQuest(NPCQuestObject.avaliableQuestIDs[j]);
                        //pass quest UI
                        QuestUIManager.questUIManager.questAvaliable = true;
                        QuestUIManager.questUIManager.avaliableQuests.Add(questList[i]);
                    }
                }
            }
        }
        //Chech for active quests
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.recievableQuestIDs.Count; j++)
            {
                if (currentQuestList[i].id == NPCQuestObject.recievableQuestIDs[j] &&
                    currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED ||
                    currentQuestList[i].progress == Quest.QuestProgress.COMPLETE)
                {
                    Debug.Log("Quest ID: " + NPCQuestObject.recievableQuestIDs[j] + " is " +
                        currentQuestList[i].progress);

                    //CompleteQuest(NPCQuestObject.recievableQuestIDs[j]);
                    //Quest UI Manager
                    QuestUIManager.questUIManager.questRunning = true;
                    QuestUIManager.questUIManager.runningQuests.Add(questList[i]);
                }
            }
        }
    }

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

    //COMPLETE
    public void CompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == Quest.QuestProgress.COMPLETE)
            {
                currentQuestList[i].progress = Quest.QuestProgress.DONE;
                currentQuestList.Remove(currentQuestList[i]);

                //REWARDS FOR COMPLETION
            }
        }
        //Check for chain quest
        CheckChainQuest(questID);
    }

    //CHECK CHAIN QUEST
    void CheckChainQuest(int questID)
    {
        int tempID = 0;
        for(int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].nextQuest > 0)
            {
                tempID = questList[i].nextQuest;
            }
        }

        if (tempID > 0)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                if(questList[i].id == tempID && questList[i].progress == Quest.QuestProgress.NOT_AVALIABLE)
                {
                    questList[i].progress = Quest.QuestProgress.AVALIABLE;
                }
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

    //BOOLS 2
    public bool CheckAvaliableQuests(QuestObject NPCQuestObject)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.avaliableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.avaliableQuestIDs[j] &&
                   questList[i].progress == Quest.QuestProgress.AVALIABLE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckAcceptedQuests(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.recievableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.recievableQuestIDs[j] &&
                   questList[i].progress == Quest.QuestProgress.ACCEPTED)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCompleteQuests(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.recievableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.recievableQuestIDs[j] &&
                   questList[i].progress == Quest.QuestProgress.COMPLETE)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
