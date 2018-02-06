using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrollBridge
{
    public class DialogueManager : MonoBehaviour
    {
        Action_Key_Dialogue action_Key_dialogue;
        public GameObject questDialogue;
        public GameObject[] dialoguesToChangeState;

        // Use this for initialization
        void Start()
        {
            if(questDialogue != null)
                action_Key_dialogue = questDialogue.GetComponent<Action_Key_Dialogue>();
        }

        // Update is called once per frame
        void Update()
        {
            if (questDialogue != null)
            {
                if (action_Key_dialogue.completed == true)
                {
                    foreach (GameObject obj in dialoguesToChangeState)
                    {
                        if (!obj.activeSelf)
                            obj.SetActive(true);
                        else
                            obj.SetActive(false);
                    }
                    this.enabled = false;
                }
            }
        }
    }
}
