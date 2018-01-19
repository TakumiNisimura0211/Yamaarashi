using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Animator anim;
    private bool moveFlg = false;
    GameObject player;

    public float speed = 0.05f; //移動速度

    private bool isEnable = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        Vector3 moveDirection = Vector3.zero;
        if (isEnable == true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 1)
            {
                anim.SetBool("moveFlg", true);
                Vector3 playerDirection = player.transform.position;
                transform.LookAt(player.transform);
                moveDirection += transform.forward * 0.05f;
                transform.position += moveDirection;
            }
        }
        else if(isEnable==false)
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
            Destroy(gameObject,0.5f);
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            isEnable = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            isEnable = false;
        }
    }

}
