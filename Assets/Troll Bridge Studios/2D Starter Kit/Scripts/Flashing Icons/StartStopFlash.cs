using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TrollBridge
{
    public class StartStopFlash : MonoBehaviour { 
        public bool startFlash = true;
        public bool endFlash = false;

        public bool onAwakeFlash = false;

        public int flashIndex =0;

        private void Awake()
        {
            Debug.Log("Object Awoken");
            if (onAwakeFlash)
            {
                Debug.Log("Flash Started");
                ObjectsToFlash.objToFlash.indexToFlash = flashIndex;
                ObjectsToFlash.objToFlash.StartUIFlash();
                gameObject.SetActive(false);
            }
        }

        public void EndFlash()
        {
            if(endFlash)
                ObjectsToFlash.objToFlash.StopUIFlash();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (startFlash && collision.tag == "Player")
            {
                ObjectsToFlash.objToFlash.indexToFlash = flashIndex;
                ObjectsToFlash.objToFlash.StartUIFlash();
                gameObject.SetActive(false);
            }
        }
    }
}
