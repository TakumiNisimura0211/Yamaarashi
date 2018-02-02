using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

    int minute;
    float second;
    //前のUpdate時の秒数
    float oldsecond;
    Text timetext;
    string rText;

	// Use this for initialization
	void Start () {
        minute = 0;
        second = 0f;
        oldsecond = 0f;
        timetext = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        second += Time.deltaTime;
        if(second >= 60.0f)
        {
            minute++;
            second = second - 60.0f;
        }
        //値が切り替わった時だけ更新
        if((int)second != (int)oldsecond)
        {
            timetext.text = "Time " + minute.ToString("00") + ":" + ((int)second).ToString("00");
            rText = minute.ToString("00") + ":" + ((int)second).ToString("00");
        }
        oldsecond = second;
	}

    public string GetTime()
    {
        return rText;
    }
}
