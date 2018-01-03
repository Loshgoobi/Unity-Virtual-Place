using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script to apply to the object used in the quest
/// </summary>
public class QuestObject : MonoBehaviour {

    private bool inTrigger = false;

    public List<int> availableQuestIDs = new List<int>();
    public List<int> receivableQuestIDs = new List<int>();

    public GameObject questMarker;
    public Image theImage;

    public Sprite questAvailableSprite;
    public Sprite questReceivableSprite;

    // Use this for initialization
    void Start ()
    {
        //setQuestMarker();
	}
	
    void setQuestMarker()
    {
        if(QuestManager.questManager.CheckCompletedQuest(this))
        {
            questMarker.SetActive(true);
            theImage.sprite = questReceivableSprite;
            theImage.color = Color.yellow;
        }
        else if(QuestManager.questManager.CheckAvailableQuest(this))
        {
            questMarker.SetActive(true);
            theImage.sprite = questAvailableSprite;
            theImage.color = Color.yellow;
        }
        else if(QuestManager.questManager.CheckAvailableQuest(this))
        {
            questMarker.SetActive(true);
            theImage.sprite = questReceivableSprite;
            theImage.color = Color.gray;
        }
    }
	// Update is called once per frame
	void Update ()
    {
		if (inTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            //quest ui manager

            QuestManager.questManager.QuestRequest(this);
        }
	}

    void onTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = true;
        }
    }
    void onTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
