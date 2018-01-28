using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TrollBridge
{
    public class QuestObject : MonoBehaviour
    {

        private bool inTrigger = false;

        public List<int> avaliableQuestIDs = new List<int>();
        public List<int> recievableQuestIDs = new List<int>();

        public GameObject questMarker;
        public Image theImage;

        public Sprite questAvaliableSprite;
        public Sprite questReceivableSprite;

        // Use this for initialization
        void Start()
        {
            SetQuestMarker();
        }

        public void SetQuestMarker()
        {
            if (QuestManager.questManager.CheckCompleteQuests(this))
            {
                questMarker.SetActive(true);
                theImage.sprite = questReceivableSprite;
                theImage.color = Color.blue;
            }
            else if (QuestManager.questManager.CheckAvaliableQuests(this))
            {
                questMarker.SetActive(true);
                theImage.sprite = questAvaliableSprite;
                theImage.color = Color.cyan;
            }
            else if (QuestManager.questManager.CheckAcceptedQuests(this))
            {
                questMarker.SetActive(true);
                theImage.sprite = questReceivableSprite;
                theImage.color = Color.gray;
            }
            else
            {
                questMarker.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {

            if (inTrigger && Input.GetKeyDown(KeyCode.Space) && !QuestUIManager.questUIManager.questPanelActive)
            {
                QuestUIManager.questUIManager.CheckQuests(this);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                inTrigger = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                inTrigger = false;
            }
        }




    }
}
