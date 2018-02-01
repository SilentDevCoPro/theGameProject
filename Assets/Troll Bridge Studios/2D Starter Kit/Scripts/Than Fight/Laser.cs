using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private LineRenderer lineRenderer;
    public Transform laserHit;


	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
	}
	
	// Update is called once per frame
	void Update () {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserHit.transform.position);
        lineRenderer.enabled = true;
	}
}
