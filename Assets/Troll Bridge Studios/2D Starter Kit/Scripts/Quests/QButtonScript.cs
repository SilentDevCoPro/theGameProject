using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TrollBridge
{
    public class QButtonScript : MonoBehaviour
    {

        public int questID;
        public Text questTitle;

        private GameObject findAcceptButton;
        private GameObject findDeclineButton;

        private Button acceptButton;
        private Button declineButton;

        private QButtonScript acceptButtonScript;
        private QButtonScript declineButtonScript;

        private GameObject textAccept;
        private GameObject textDecline;

        private Text textAcceptScript;
        private Text textDeclineScript;


        private void Start()
        {
            textAccept = GameObject.Find("TextButtonAccept");
            textAcceptScript = textAccept.GetComponent<Text>();

            textDecline = GameObject.Find("TextButtonDecline");
            textDeclineScript = textDecline.GetComponent<Text>();

            findAcceptButton = GameObject.Find("Accept").gameObject;
            acceptButtonScript = findAcceptButton.GetComponent<QButtonScript>();
            acceptButton = findAcceptButton.GetComponent<Button>();

            findDeclineButton = GameObject.Find("Decline").gameObject;
            declineButtonScript = findDeclineButton.GetComponent<QButtonScript>();
            declineButton = findDeclineButton.GetComponent<Button>();

            textAcceptScript.color = Color.clear;
            textDeclineScript.color = Color.clear;

            acceptButton.interactable = false;
            declineButton.interactable = false;

        }

        //Show all information
        public void ShowAllInformation()
        {
            QuestUIManager.questUIManager.ShowSelectedQuest(questID);

            //Accept button
            if (QuestManager.questManager.RequestAvaliableQuest(questID))
            {
                textAcceptScript.color = Color.white;
                textDeclineScript.color = Color.white;
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
            GameObject.Find("Player Manager(Clone)").GetComponent<Player_Manager>().CanMove = true;
            QuestUIManager.questUIManager.HideQuestPanel();
            acceptButton.interactable = false;
            declineButton.interactable = false;
        }

        public void AcceptQuest()
        {
            GameObject.Find("Player Manager(Clone)").GetComponent<Player_Manager>().CanMove = true;
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
            GameObject.Find("Player Manager(Clone)").GetComponent<Player_Manager>().CanMove = true;
            QuestUIManager.questUIManager.HideQuestPanel();

            //Update all quest Objects

            QuestObject[] currentQuestObjects = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
            foreach (QuestObject qobj in currentQuestObjects)
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
}
