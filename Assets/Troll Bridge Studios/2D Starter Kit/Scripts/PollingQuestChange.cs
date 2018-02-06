using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TrollBridge
{
    public class PollingQuestChange : MonoBehaviour
    {

        public int questID;
        public GameObject[] gameObjectsToActivate;
        public GameObject[] gameObjectsToDeactivate;

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < QuestManager.questManager.questList.Count; i++)
            {
                if (QuestManager.questManager.questList[i].id == questID)
                {
                    if (QuestManager.questManager.questList[i].progress == Quest.QuestProgress.ACCEPTED)
                    {
                        foreach (GameObject obj in gameObjectsToActivate)
                        {
                            if (!obj.activeSelf)
                            {
                                obj.SetActive(true);
                            }
                        }

                        foreach (GameObject obj in gameObjectsToDeactivate)
                        {
                            if (obj.activeSelf)
                                obj.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}

