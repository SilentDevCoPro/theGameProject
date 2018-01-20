using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrollBridge
{
    public class AreaDialogueManager : MonoBehaviour
    {
        Area_Dialogue area_dialogue;
        public GameObject questDialogue;
        public GameObject[] dialoguesToChangeState;

        // Use this for initialization
        void Awake()
        {
            if (questDialogue != null)
            {
                area_dialogue = questDialogue.GetComponent<Area_Dialogue>();
                
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (questDialogue != null)
            {
                if (area_dialogue.completed)
                {
                    foreach (GameObject obj in dialoguesToChangeState)
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
