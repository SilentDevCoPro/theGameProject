using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrollBridge {

    public class MinionDeath : MonoBehaviour
    {
        public GameObject fightController;
        // Use this for initialization
        void Awake()
        {
            fightController.GetComponent<BossFight>().isMinionDead = true;
        }
    }
}
