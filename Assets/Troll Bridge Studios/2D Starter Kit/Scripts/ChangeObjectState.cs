using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectState : MonoBehaviour {

    public GameObject goToChangeState;

    public void ChangeState()
    {
        goToChangeState.SetActive(false);
    }
}
