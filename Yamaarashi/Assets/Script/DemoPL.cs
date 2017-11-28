﻿using UnityEngine;
using System.Collections;

public class DemoPL : MonoBehaviour {

    float moveSpeed,maxSpeed,minSpeed;
    public DemoCA camera;
    public bool stay = false;

	// Use this for initialization
	void Start () {
        moveSpeed = 0.5f;
        maxSpeed = 10.0f;
        minSpeed = 3.0f;
        this.gameObject.transform.forward = camera.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed;
        }

        this.gameObject.transform.forward = camera.transform.forward;
    }

    private void OnTriggerEnter(Collider collision)
    {
        camera.Enter(collision);
    }

    private void OnTriggerExit(Collider collision)
    {
        camera.Exit(collision);
    }

    /*private void OnTriggerStay(Collider collision)
    {
        camera.Stay(collision);
    }*/
}
