using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Quest{
    //Current state of the quest
    public enum QuestProgress { NOT_AVALIABLE, AVALIABLE, ACCEPTED, COMPLETE, DONE}
   
    //Quest title
    public string title; 
    //ID of the quest
    public int id;
    //State of the current quest 
    public QuestProgress progress;
    //String for quest giver/reciever
    [TextArea]
    public string description;
    //String for previous quest hits
    [TextArea]
    public string[] crossedOutHint;
    //String for quest giver/reciever
    [TextArea]
    public string hint;
    //String for quest giver/reciever
    public string congratulations;
    //String for quest giver/reciever
    public string sumary;
    //The next quest ID if there is any
    public int nextQuest;

    //Name of the quest objectives
    public string questObjective;
    //Current number of objectives
    public int questObjectivesCount;
    //Required amount of quest objective objects
    public int questObjectiveRequirement;

    //REWARDS GO HERE
    public int moneyReward;
    public int itemReward;
}
