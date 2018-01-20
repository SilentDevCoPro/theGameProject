using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour {

    public static QuestUIManager questUIManager;

    //BOOLS
    public bool questAvaliable = false;
    public bool questRunning = false;
    public bool questPanelActive = false;
    public bool questLogPanelActive = false;

    //Panels
    public GameObject questPanel;
    public GameObject questLogPanel;

    //QuestObject
    public QuestObject currentQuestObject;

    //Ques tLists
    public List<Quest> avaliableQuests = new List<Quest>();
    public List<Quest> runningQuests = new List<Quest>();

    //Buttons
    public GameObject qButton;
    public GameObject qLogButton;

    private List<GameObject> qButtons = new List<GameObject>();

    private GameObject acceptButton;
    private GameObject completeButton;

    //SPACER
    public Transform qButtonSpacerAvaliable;
    public Transform qButtonSpacerRunning;
    public Transform qButtonSpacerLog;

    //Info
    public Text questTitle;
    public Text questDescription;
    public Text questSummary;
    public Text questRewards;

    //Quest Log Info
    public Text questLogTitle;
    public Text questLogDescription;
    public Text questLogSummary;
    public Text questLogRewards;

    private void Awake()
    {
        if (questUIManager == null)
            questUIManager = this;
        else if (questUIManager != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        HideQuestPanel();
        HideQuestLogPanel();
    }
	
    //Called from the Quest Object
    public void CheckQuests(QuestObject questObject)
    {
        currentQuestObject = questObject;
        QuestManager.questManager.QuestRequest(questObject);
        if((questRunning || questAvaliable) && !questLogPanelActive)
        {
            ShowQuestPanel();
        }
        else
        {
            Debug.Log("No Quests Avaliable");
        }
    }

    //Show panel
    public void ShowQuestPanel()
    {
        questPanelActive = true;
        questPanel.SetActive(true);
        FillQuestButtons();
    }

    //Show quest log panel
    public void ShowQuestLogPanel()
    {
        questLogPanel.SetActive(true);
        if (questLogPanelActive && !questPanelActive)
        {
            foreach(Quest currentQuest in QuestManager.questManager.currentQuestList)
            {
                GameObject questButton = Instantiate(qLogButton);
                QLogButtonScipt qButton = questButton.GetComponent<QLogButtonScipt>();

                
                qButton.questID = currentQuest.id;
                qButton.questTitle.text = currentQuest.title;
                questButton.transform.SetParent(qButtonSpacerLog, false);
                qButtons.Add(questButton);
            }
        }
        else if(!questLogPanelActive && !questLogPanelActive)
        {
            HideQuestLogPanel();
        }
    }

    //Show quest log
    public void ShowQuestLog(Quest runningQuest)
    {
        questLogTitle.text = runningQuest.title;

        if(runningQuest.progress == Quest.QuestProgress.ACCEPTED)
        {
            questLogDescription.text = runningQuest.hint;
            questLogSummary.text = runningQuest.questObjective + ": " + runningQuest.questObjectivesCount + " / " + runningQuest.questObjectiveRequirement;
        }
        else if (runningQuest.progress == Quest.QuestProgress.COMPLETE)
        {
            questLogDescription.text = runningQuest.congratulations;
            questLogSummary.text = runningQuest.questObjective + ": " + runningQuest.questObjectivesCount + " / " + runningQuest.questObjectiveRequirement;

        }
    }

    //Hides quest log
    public void HideQuestPanel()
    {
        questPanelActive = false;
        questAvaliable = false;
        questRunning = false;

        //Clear all text fields
        questTitle.text = "Quest Menu";
        questDescription.text = "Select an avaliable or running quest from the left hand side panel to get started!";
        questSummary.text = "";
        questRewards.text = "";
        

        //Clear lists
        runningQuests.Clear();
        avaliableQuests.Clear();

        //Clear buttons
        for(int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }

        qButtons.Clear();

        //Hide panel
        questPanel.SetActive(false);
    }

    //Hide quest log panel
    public void HideQuestLogPanel()
    {
        questLogPanelActive = false;

        questLogTitle.text = "Quest Log Menu";
        questLogDescription.text = "Select a quest from the left hand side panel to view your progress!";
        questLogSummary.text = "";
        questLogRewards.text = "";

        //Clear buttons
        for(int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }
        qButtons.Clear();
        questLogPanel.SetActive(false);
    }

    //Fill buttons for quest panel
    void FillQuestButtons()  
    {
        foreach(Quest avaliableQuest in avaliableQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qbsScript = questButton.GetComponent<QButtonScript>();
            qbsScript.questID = avaliableQuest.id;
            qbsScript.questTitle.text = avaliableQuest.title;

            questButton.transform.SetParent(qButtonSpacerAvaliable, false);
            qButtons.Add(questButton);
        }

        foreach (Quest runningQuest in runningQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qbsScript = questButton.GetComponent<QButtonScript>();
            qbsScript.questID = runningQuest.id;
            qbsScript.questTitle.text = runningQuest.title;

            questButton.transform.SetParent(qButtonSpacerRunning, false);
            qButtons.Add(questButton);
        }
    }

    //Show quest on button press in quest panel
    public void ShowSelectedQuest(int questID)
    {
        for(int i = 0; i < avaliableQuests.Count; i++)
        {
            if (avaliableQuests[i].id == questID)
            {
                questTitle.text = avaliableQuests[i].title;
                if(avaliableQuests[i].progress == Quest.QuestProgress.AVALIABLE)
                {
                    questDescription.text = avaliableQuests[i].description;
                    //THIS IS THE QUEST OBJECTIVE
                    //questSummary.text = avaliableQuests[i].questObjective + ": " + avaliableQuests[i].questObjectivesCount + " / " + avaliableQuests[i].questObjectiveRequirement;
                }
            }
        }

        for(int i = 0; i < runningQuests.Count; i++)
        {
            if(runningQuests[i].id == questID)
            {
                questTitle.text = runningQuests[i].title;
                if(runningQuests[i].progress == Quest.QuestProgress.ACCEPTED)
                {
                    questDescription.text = runningQuests[i].hint;
                    questSummary.text = runningQuests[i].questObjective + ": " + runningQuests[i].questObjectivesCount + " / " + runningQuests[i].questObjectiveRequirement;

                }
                else if(runningQuests[i].progress == Quest.QuestProgress.COMPLETE)
                {
                    questDescription.text = runningQuests[i].congratulations;
                    questSummary.text = runningQuests[i].questObjective + ": " + runningQuests[i].questObjectivesCount + " / " + runningQuests[i].questObjectiveRequirement;
                }
            }
        }
    }

}
