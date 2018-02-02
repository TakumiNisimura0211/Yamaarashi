using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    public Score score;
    public TimeText time;

    ResultController result;

    public static int rScore;
    public static string rtext;

	// Use this for initialization
	void Start () {
        rScore = 0;
        rtext = null;
	}
	
	// Update is called once per frame
	void Update () {
		if(score != null && time != null)
        {
            rScore = score.Scores;
            rtext = time.GetTime();
        }
	}
}
