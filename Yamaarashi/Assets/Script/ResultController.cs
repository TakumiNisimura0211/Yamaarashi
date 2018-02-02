using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour {

    public Text score,time;

	// Use this for initialization
	void Start () {
        score.text = Result.rScore.ToString();
        time.text = Result.rtext;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
