using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public Score ScoreScript;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //プレイヤーと衝突したとき
        if (collision.gameObject.tag == "Player")
        {
            ScoreScript.ScoreUp();
            //ボックスを削除する。
            Destroy(gameObject);
        }
    }
}
