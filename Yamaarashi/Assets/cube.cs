﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cube : MonoBehaviour {

    public PostEffectTest pe;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("satge_2.1");
        }

    }
}
