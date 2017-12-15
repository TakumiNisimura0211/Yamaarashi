﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    Rigidbody rb;
    public float JumpPower = 25;
    public bool jump = false;
    GameObject player;

	void Start () {
        //player = GameObject.Find("Player");
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag== "Player")
        {
            if(jump)
            {
                player.GetComponent<Rigidbody>().AddForce(transform.up * JumpPower * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }

}
