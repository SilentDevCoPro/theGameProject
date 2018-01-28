using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrollBridge
{
    public class OnQuestStart : MonoBehaviour
    {

        public int questID;
        public GameObject[] gameObjectsToChangeState;

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < QuestManager.questManager.currentQuestList.Count; i++)
            {
                if (QuestManager.questManager.currentQuestList[i].id == questID)
                {
                    if (QuestManager.questManager.currentQuestList[i].progress == Quest.QuestProgress.ACCEPTED)
                    {
                        foreach (GameObject obj in gameObjectsToChangeState)
                        {
                            if (!obj.activeSelf)
                                obj.SetActive(true);
                            else
                                obj.SetActive(false);
                        }
                        Destroy(this);
                    }
                }
            }
        }
    }
}
