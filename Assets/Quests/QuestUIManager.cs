using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour {


    public static QuestUIManager uiManager;

    // BOOLS
    public bool questAvailable = false;
    public bool questRunning = false;
    private bool panelActive = false;
    private bool questPanelActive = false;

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
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            questPanelActive = !questPanelActive;
            //showQuestLogPanel
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

    // quest log



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


}
