using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrollBridge
{
    public class OnDeath : MonoBehaviour
    {

        private NPC_Manager npc_manager;
        public GameObject npcManagerObject;
        public GameObject[] gameObjectsToChangeState;

        // Use this for initialization
        void Start()
        {
            if (npcManagerObject != null)
                npc_manager = npcManagerObject.GetComponent<NPC_Manager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (npcManagerObject != null)
            {
                if(npc_manager.dead)
                {
                    foreach(GameObject obj in gameObjectsToChangeState)
                    {
                        if (!obj.activeSelf)
                            obj.SetActive(true);
                        else
                            obj.SetActive(false);
                    }
                    DestroyObject(this);
                }
            }
        }
    }
}
