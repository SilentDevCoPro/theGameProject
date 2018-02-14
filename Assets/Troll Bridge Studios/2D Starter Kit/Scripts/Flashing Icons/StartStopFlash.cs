﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TrollBridge
{
    public class StartStopFlash : MonoBehaviour { 
        public bool startFlash = true;
        public bool endFlash = false;

        public int flashIndex =0;

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
