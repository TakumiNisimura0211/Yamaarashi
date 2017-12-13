using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Animator anim;
    private bool moveFlg = false;
    GameObject player;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {
        if(Vector3.Distance(this.gameObject.transform.position,player.transform.position) <= 4.5f)
        {
            anim.SetBool("moveFlg", true);
        }
        else if(Vector3.Distance(this.gameObject.transform.position, player.transform.position) > 4.5f)
        {
            anim.SetBool("moveFlg", false);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        //プレイヤーと衝突したとき
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Death");
        }
    }
}
