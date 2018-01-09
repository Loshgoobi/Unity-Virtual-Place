using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QButtonScript : MonoBehaviour {

    public int questID;
    public Text questTitle;

    private GameObject acceptButton;
    private GameObject giveupButton;
    private GameObject completeButton;

    private QButtonScript acceptButtonScript;
    private QButtonScript giveupButtonScript;
    private QButtonScript completeButtonScript;

    private void Start()
    {
        //FindChild() a partir 
        acceptButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("Buttons").transform.Find("AcceptButton").gameObject;
        acceptButtonScript = acceptButton.GetComponent<QButtonScript>();

        acceptButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("Buttons").transform.Find("GiveUpButton").gameObject;
        acceptButtonScript = giveupButton.GetComponent<QButtonScript>();

        acceptButton = GameObject.Find("QuestCanvas").transform.Find("QuestPanel").transform.Find("QuestDescription").transform.Find("Buttons").transform.Find("CompleteButton").gameObject;
        acceptButtonScript = completeButton.GetComponent<QButtonScript>();

        acceptButton.SetActive(false);
        giveupButton.SetActive(false);
        completeButton.SetActive(false);

    }

    //SHOW ALL INFOS
    public void ShowAllInfos()
    {
        QuestUIManager.uiManager.ShowSelectedQuest(questID);
        //ACCEPT BUTTON
        if(QuestManager.questManager.RequestAvailableQuest(questID))
        {
            acceptButton.SetActive(true);
            acceptButtonScript.questID = questID;
        }
        else
        {
            acceptButton.SetActive(false);
        }

        //GIVE UP BUTTON
        if (QuestManager.questManager.RequestAvailableQuest(questID))
        {
            giveupButton.SetActive(true);
            giveupButtonScript.questID = questID;
        }
        else
        {
            giveupButton.SetActive(false);
        }

        //COMPLETE BUTTON
        if (QuestManager.questManager.RequestAvailableQuest(questID))
        {
            completeButton.SetActive(true);
            completeButtonScript.questID = questID;
        }
        else
        {
            completeButton.SetActive(false);
        }
    }

    public void AcceptQuest()
    {
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();


        //UPDATE ALL NPCS
        QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach(QuestObject obj in currentQuestGuys)
        {
           // obj.setQuestMarker();
        }

    }

    public void GiveUpQuest()
    {
        QuestManager.questManager.GiveUpQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();


        //UPDATE ALL NPCS
        QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject obj in currentQuestGuys)
        {
            //obj.setQuestMarker();
        }

    }

    public void CompleteQuest()
    {
        QuestManager.questManager.CompleteQuest(questID);
        QuestUIManager.uiManager.HideQuestPanel();


        //UPDATE ALL NPCS
        QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject obj in currentQuestGuys)
        {
          //  obj.setQuestMarker();
        }

    }

    public void ClosePanel()
    {
        QuestUIManager.uiManager.HideQuestPanel();
    }



}
