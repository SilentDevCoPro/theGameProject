using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TrollBridge
{
    public class OpenQuestInterface : MonoBehaviour
    {

        public void Open()
        {
            QuestUIManager.questUIManager.questLogPanelActive = !QuestUIManager.questUIManager.questLogPanelActive;
            QuestUIManager.questUIManager.ShowQuestLogPanel();
        }
    }
}
