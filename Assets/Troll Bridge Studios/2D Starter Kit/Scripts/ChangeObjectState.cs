using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectState : MonoBehaviour {

    public GameObject goToChangeState;

    public void ChangeState()
    {
        if(goToChangeState.activeSelf)
            goToChangeState.SetActive(false);
        else
            goToChangeState.SetActive(true);
    }
}
