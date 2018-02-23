using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour {

    public Text text;

    private void Start()
    {
        text.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.enabled = false;
    }
}
