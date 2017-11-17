using UnityEngine;
using System.Collections;

public class box : MonoBehaviour {

    public Score ScoreScript;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter(Collision collision)
    {
        //プレイヤーと衝突したとき
        if(collision.gameObject.tag=="Player")
        {
            ScoreScript.ScoreUp();
            //ボックスを削除する。
            Destroy(gameObject);
        }
    }
}
