using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalLink : MonoBehaviour {

    public string link;

    public void OpenURL() {
        Application.OpenURL(link);
    }
}
