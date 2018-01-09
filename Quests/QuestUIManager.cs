﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour {


    public static QuestUIManager uiManager;

    // BOOLS
    public bool questAvailable = false;
    public bool questRunning = false;
    private bool questPanelActive = false;
    private bool questLogPanelActive = false;

    //PANELS
    public GameObject questPanel;
    public GameObject questLogPanel;

    //QUESTOBJECT
    private QuestObject currentQuestObject;

    //QUESTLISTS
    public List<Quest> availableQuests = new List<Quest>();
    public List<Quest> activeQuests = new List<Quest>();

    //BUTTONS
    public GameObject qButton;
    public GameObject qLogButton;
    private List<GameObject> qButtons = new List<GameObject>();

    private GameObject acceptButton;
    private GameObject giveupButton;
    private GameObject completeButton;

    //SPACER
    public Transform qButtonSpacer; //qButton available
    public Transform qButtonSpacer2; //running qButton
    public Transform qLogButtonSpacer; //running in qLog

    //QUEST INFOS
    public Text questTitle;
    public Text questDescription;
    public Text questSummary;

    //QUEST LOG INFOS
    public Text questLogTitle;
    public Text questLogDescription;
    public Text questLogSummary;


    void Awake()
    {
        if(uiManager == null)
        {
            uiManager = this;
        }
        else if( uiManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        HideQuestPanel();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E))
        {
            questLogPanelActive = !questLogPanelActive;
            ShowQuestLogPanel();
            Debug.Log("yaaaayy!!");
        }
	}

    //CALLED FROM QUEST OBJECT
    public void CheckQuests(QuestObject questObject)
    {
        currentQuestObject = questObject;
        QuestManager.questManager.QuestRequest(questObject);
        if((questRunning || questAvailable) && !questPanelActive)
        {
            ShowQuestPanel();
        }
        else
        {
            Debug.Log("No Quests Available.");
        }

    }

    //SHOW PANEL
    public void ShowQuestPanel()
    {
        questPanelActive = true;
        questPanel.SetActive(questPanelActive);
        //FILL IN DATA


    }
    
    public void ShowQuestLog(Quest activeQuest)
    {
        questLogTitle.text = activeQuest.title;
        if (activeQuest.progress == Quest.QuestProgress.ACCEPTED)
        {
            questLogDescription.text = activeQuest.hint;
            questSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequirement;
        }
        else if (activeQuest.progress == Quest.QuestProgress.COMPLETE)
        {
            questLogDescription.text = activeQuest.hint;
            questSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequirement;
        }
    } 

    public void ShowQuestLogPanel()
    {
        questLogPanel.SetActive(questLogPanelActive);
        if (questLogPanelActive && !questLogPanelActive)
        {
            foreach (Quest curQuest in QuestManager.questManager.currentQuestList)
            {
                GameObject questButton = Instantiate(qLogButton);
                QLogButtonScript qButton = questButton.GetComponent<QLogButtonScript>();

                qButton.questID = curQuest.id;
                qButton.questTitle.text = curQuest.title;

                questButton.transform.SetParent(qLogButtonSpacer, false);
                qButtons.Add(questButton);
            }
        }
        else if (!questLogPanelActive && !questPanelActive)
        {
            HideQuestLogPanel();
        }
    }

    
    //HIDE QUEST PANEL
    public void HideQuestPanel()
    {
        questPanelActive = false;
        questAvailable = false;
        questRunning = false;

        //CLEAR TEXT
        questTitle.text = "";
        questDescription.text = "";
        questSummary.text = "";

        //CLEAR LIST
        availableQuests.Clear();
        activeQuests.Clear();

        //CLEAR BUTTON LIST
        for(int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }
        qButtons.Clear();

        //HIDE PANEL
        questPanel.SetActive(questPanelActive);

    }

    //HIDE QUEST LOG PANEL
    public void HideQuestLogPanel()
    {
        questLogPanelActive = false;

        questLogTitle.text = "";
        questLogDescription.text = "";
        questLogSummary.text = "";

        //CLEAR BUTTON LIST
        for (int i = 0; i < qButtons.Count; i++)
        {
            qButtons.Clear();
            questLogPanel.SetActive(questLogPanelActive);
        }
    }

    //FILL BUTTONS FOR QUEST PANEL
    void FillQuestButtons()
    {
        foreach (Quest availableQuest in availableQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBscript = questButton.GetComponent<QButtonScript>();

            qBscript.questID = availableQuest.id;
            qBscript.questTitle.text = availableQuest.title;

            questButton.transform.SetParent(qButtonSpacer, false);
            qButtons.Add(questButton);
        }

        foreach (Quest activeQuest in activeQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBscript = questButton.GetComponent<QButtonScript>();

            qBscript.questID = activeQuest.id;
            qBscript.questTitle.text = activeQuest.title;

            questButton.transform.SetParent(qButtonSpacer2, false);
            qButtons.Add(questButton);
        }
    }

    //SHOW QUEST ON BUTTON PRESS IN QUEST PANEL
    public void ShowSelectedQuest(int questID)
    {
        for(int i = 0; i < availableQuests.Count; i++)
        {
            if(availableQuests[i].id == questID)
            {
                questTitle.text = availableQuests[i].title;
                if (availableQuests[i].progress == Quest.QuestProgress.AVAILABLE)
                {
                    questDescription.text = availableQuests[i].description;
                    questSummary.text = availableQuests[i].questObjective + " : " + availableQuests[i].questObjectiveCount + " / " + availableQuests[i].questObjectiveRequirement;
                }
            }
        }

        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].id == questID)
            {
                questTitle.text = activeQuests[i].title;
                if (activeQuests[i].progress == Quest.QuestProgress.ACCEPTED)
                {
                    questDescription.text = activeQuests[i].hint;
                    questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + " / " + activeQuests[i].questObjectiveRequirement;
                }
                else if(activeQuests[i].progress == Quest.QuestProgress.COMPLETE)
                {
                    questDescription.text = activeQuests[i].congatulation;
                }
            }
        }
    }

}
