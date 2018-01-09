using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest {

    public enum QuestProgress {NOT_AVAILABLE, AVAILABLE, ACCEPTED, COMPLETE, DONE}

    public string title;            //title for the quest
    public int id;                  //ID number for the quest
    public QuestProgress progress;  //state of the current quest (enum)
    public string description;      //string from our quest Giver/Reciever
    public string hint;             //string from our quest Giver/Reciever
    public string congatulation;    //string from our quest Giver/Reciever
    public string summary;          //string from our quest Giver/Reciever
    public int nextQuest;           //ID of the next quest (if there is any)

    public string questObjective;   //name of the quest objective (can be int id of object)(also for remove)
    public int questObjectiveCount; //current number of questObjective count
    public int questObjectiveRequirement;//required amount of quest objective objects

    public int expReward;
    public int goldReward;
    public string itemReward;

}
