using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TrollBridge
{
    public class QLogButtonScipt : MonoBehaviour
    {

        public int questID;
        public Text questTitle;

        public void ShowAllInformation()
        {
            QuestManager.questManager.ShowQustLog(questID);
        }

        public void ClosePanel()
        {
            GameObject.Find("Player Manager(Clone)").GetComponent<Player_Manager>().CanMove = true;
            QuestUIManager.questUIManager.HideQuestLogPanel();
        }
    }
}
