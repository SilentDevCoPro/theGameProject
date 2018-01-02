using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QButtonScript : MonoBehaviour {

    public int questID;
    public Text questTitle;

    private GameObject acceptButton;
    private GameObject declineButton;

    private QButtonScript acceptButtonScript;
    private QButtonScript declineButtonScript;

    private void Start()
    {
        //acceptButton = 
    }

    //Show all information
    public void ShowAllInformation()
    {
        QuestUIManager.questUIManager.ShowSelectedQuest(questID);
    }

    public void closeQuestPanel()
    {
        QuestUIManager.questUIManager.HideQuestPanel();
    }
}
