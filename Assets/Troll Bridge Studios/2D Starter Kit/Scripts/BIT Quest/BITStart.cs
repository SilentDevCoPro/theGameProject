using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BITStart : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        QuestManager.questManager.AddQuestItem("Look around the city", 1);
    }
}
