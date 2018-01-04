using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QButtonScript : MonoBehaviour {

    public int questID;
    public Text questTitle;

    private GameObject findAcceptButton;
    private GameObject findDeclineButton;

    private Button acceptButton;
    private Button declineButton;

    private QButtonScript acceptButtonScript;
    private QButtonScript declineButtonScript;

    private void Start()
    {
        findAcceptButton = GameObject.Find("Accept").gameObject;
        acceptButtonScript = findAcceptButton.GetComponent<QButtonScript>();
        acceptButton = findAcceptButton.GetComponent<Button>();

        findDeclineButton = GameObject.Find("Decline").gameObject;
        declineButtonScript = findDeclineButton.GetComponent<QButtonScript>();
        declineButton = findDeclineButton.GetComponent<Button>();

        acceptButton.interactable = false;
        declineButton.interactable = false;
    }

    //Quest UI
    public void OpenQuestInterface()
    {
        QuestUIManager.questUIManager.questLogPanelActive = !QuestUIManager.questUIManager.questLogPanelActive;
        QuestUIManager.questUIManager.ShowQuestLogPanel();
    }

    //Show all information
    public void ShowAllInformation()
    {
        QuestUIManager.questUIManager.ShowSelectedQuest(questID);

        //Accept button
        if(QuestManager.questManager.RequestAvaliableQuest(questID))
        {
            acceptButton.interactable = true;
            declineButton.interactable = true;
            acceptButtonScript.questID = questID;
        }
        else
        {
            //declineButton.SetActive(false);
            //acceptButton.SetActive(false);
        }
    }

    public void CloseQuestPanel()
    {
        QuestUIManager.questUIManager.HideQuestPanel();
    }

    public void AcceptQuest()
    {
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.questUIManager.HideQuestPanel();

        //Update all quest Objects

        QuestObject[] currentQuestObjects = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject qobj in currentQuestObjects)
        {
            qobj.SetQuestMarker();
        }
    }

    public void DeclineQuest()
    {
        QuestUIManager.questUIManager.HideQuestPanel();

        //Update all quest Objects

        QuestObject[] currentQuestObjects = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach(QuestObject qobj in currentQuestObjects)
        {
            qobj.SetQuestMarker();
        }
    }

    public void CompleteQuest()
    {
        QuestManager.questManager.CompleteQuest(questID);
        QuestUIManager.questUIManager.HideQuestPanel();

        //Update all quest Objects

        QuestObject[] currentQuestObjects = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject qobj in currentQuestObjects)
        {
            qobj.SetQuestMarker();
        }
    }
}
