using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QLogButtonScipt : MonoBehaviour {

    public int questID;
    public Text questTitle;



    public void ShowAllInformation()
    {
        QuestManager.questManager.ShowQustLog(questID);
    }

    public void ClosePanel()
    {
        QuestUIManager.questUIManager.HideQuestLogPanel();
    }
}
