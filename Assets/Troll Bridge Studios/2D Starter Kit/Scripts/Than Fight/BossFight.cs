using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrollBridge {
    public class BossFight : MonoBehaviour
    {

        public int thanWalkSpeed;
        public GameObject than;

        public GameObject thanAlterLocation;
        public GameObject flipThan;

        public GameObject laser1;
        public GameObject laser2;

        public GameObject minion;
        public float minionMaxSize;
        public float minionGrowthRate;
        public float minionHalfMaxSize;
        public bool isMinionDead = false;

        private Follow_Closest_Type minionTargetControl;


        // Use this for initialization
        void Awake()
        {
            StartCoroutine(Fight());
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator Fight()
        {
            while (than.transform.position != thanAlterLocation.transform.position)
            {
                than.transform.position = Vector2.MoveTowards(than.transform.position, thanAlterLocation.transform.position, thanWalkSpeed * Time.deltaTime);
                yield return null;
            }
            while (than.transform.position != flipThan.transform.position)
            {

                than.transform.position = Vector2.MoveTowards(than.transform.position, flipThan.transform.position, thanWalkSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(2f);

            minion.SetActive(true);
            laser1.SetActive(true);
            laser2.SetActive(true);
            minionTargetControl = minion.GetComponentInChildren<Follow_Closest_Type>();
            minionTargetControl.AggroDistance = 0;

            Vector3 temp = minion.transform.localScale;
            Vector3 maxSize = new Vector3(minionMaxSize, minionMaxSize);

            while (minion.transform.localScale.x <= maxSize.x)
            {
                temp.x += minionGrowthRate;
                temp.y += minionGrowthRate;
                minion.transform.localScale = temp;
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            minionTargetControl.AggroDistance = 25;


            Character_Stats character_stats = minion.GetComponentInChildren<Character_Stats>();
            maxSize.x = minionHalfMaxSize;
            maxSize.y = minionHalfMaxSize;

            while(laser1 != null || laser2 !=null)
            {
                if(laser1 == null || laser2 == null)
                {
                    minion.transform.localScale = maxSize;
                }

                if(character_stats.GetCurrentHealth() != character_stats.GetMaxHealth())
                {
                    character_stats.CurrentHealth = character_stats.GetMaxHealth();
                }
                yield return null;
            }

            while (!isMinionDead)
            {
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            than.GetComponent<NPC_Manager>().characterType = CharacterType.Enemy;
            than.GetComponentInChildren<Follow_Closest_Type>().enabled = true;

        }
    }
}
