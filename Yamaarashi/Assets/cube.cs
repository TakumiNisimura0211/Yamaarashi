﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cube : MonoBehaviour {

    public PostEffect pe;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            //SceneManager.LoadScene("satge_2.1");

            Change();
        }
    }
    void Change()
    {
        if(Time.timeSinceLevelLoad > 4.0f)
        {
            pe.setFlg(true);
            SceneManager.LoadScene("satge_2.1");
        }
    }
}

