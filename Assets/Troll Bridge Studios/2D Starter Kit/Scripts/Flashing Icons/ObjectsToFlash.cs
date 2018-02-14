using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TrollBridge
{
    public class ObjectsToFlash : MonoBehaviour
    {
        public float flashTimer = 0.5f;

        public GameObject[] imagesToFlash;

        public int indexToFlash = 0;

        private IEnumerator coroutine;

        //private Image image;
        private bool flashing = true;

        public static ObjectsToFlash objToFlash;

        void Awake()
        {
            if (objToFlash == null)
                objToFlash = this;
            else if (objToFlash != this)
                Destroy(gameObject);

            coroutine = UIFlash();
            //image = gameObject.GetComponent<Image>();
        }

        IEnumerator UIFlash()
        {
            while (flashing)
            {
                if (!imagesToFlash[indexToFlash].GetComponent<Image>().enabled)
                {
                    imagesToFlash[indexToFlash].GetComponent<Image>().enabled = true;
                    yield return new WaitForSeconds(flashTimer);
                }
                else
                {
                    imagesToFlash[indexToFlash].GetComponent<Image>().enabled = false;
                    yield return new WaitForSeconds(flashTimer);
                }
                
            }
            imagesToFlash[indexToFlash].GetComponent<Image>().enabled = true;
        }

        public void StartUIFlash()
        {
            StopCoroutine(coroutine);
            for (int i = 0; i < imagesToFlash.Length; i++)
            {
                imagesToFlash[i].GetComponent<Image>().enabled = true;
            }
            flashing = true;
            StartCoroutine(coroutine);
        }

        public void StopUIFlash()
        {
            flashing = false;
            StopCoroutine(coroutine);
            for (int i = 0; i < imagesToFlash.Length; i++)
            {
                imagesToFlash[i].GetComponent<Image>().enabled = true;
            }
        }
    }
}
