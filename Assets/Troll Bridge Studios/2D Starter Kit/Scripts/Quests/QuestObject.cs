using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class QuestObject : MonoBehaviour {

    private bool inTrigger = false;

    public List<int> avaliableQuestIDs = new List<int>();
    public List<int> recievableQuestIDs = new List<int>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (inTrigger)
        {
            //UI
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }
    }




}
