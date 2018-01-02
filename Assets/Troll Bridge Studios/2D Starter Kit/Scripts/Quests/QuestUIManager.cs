using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour {

    public static QuestUIManager questUIManager;

    //BOOLS
    public bool questAvaliable = false;
    public bool questRunning = false;
    private bool questPanelActive = false;
    private bool questLogPanelActive = false;

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

    //Quest Log Info
    public Text questLogTitle;
    public Text questLogDescription;
    public Text questLogSummary;

    private void Awake()
    {
        if (questUIManager == null)
            questUIManager = this;
        else if (questUIManager != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        HideQuestPanel();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q))
        {
            questLogPanelActive = !questLogPanelActive;
            //Show Quest Log Panel
        }
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

    //Quest log

    public void HideQuestPanel()
    {
        questLogPanelActive = false;
        questAvaliable = false;
        questRunning = false;

        //Clear all text fields
        questTitle.text = "";
        questDescription.text = "";
        questSummary.text = "";

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
        questPanel.SetActive(questLogPanelActive);
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
                    questSummary.text = avaliableQuests[i].questObjective + ": " + avaliableQuests[i].questObjectivesCount + " / " + avaliableQuests[i].questObjectiveRequirement;
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
