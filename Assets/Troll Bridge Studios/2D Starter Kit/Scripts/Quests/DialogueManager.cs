using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrollBridge
{
    public class DialogueManager : MonoBehaviour
    {

        Action_Key_Dialogue action_Key_dialogue;
        public GameObject dialogueToDisable;
        public GameObject[] gameObjectToEnable;

        // Use this for initialization
        void Start()
        {
            if(dialogueToDisable != null)
                action_Key_dialogue = dialogueToDisable.GetComponent<Action_Key_Dialogue>();
        }

        // Update is called once per frame
        void Update()
        {
            if (dialogueToDisable != null)
            {
                if (action_Key_dialogue.completed == true)
                {
                    foreach (GameObject obj in gameObjectToEnable)
                    {
                        obj.SetActive(true);
                    }
                    dialogueToDisable.SetActive(false);
                }
            }
        }
    }
}
