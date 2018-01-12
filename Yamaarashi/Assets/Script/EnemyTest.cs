using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵の動き制御。距離を考慮するタイプ
public class enemytest : MonoBehaviour
{
    GameObject player;
    float speed = 1.0f;

    private bool isEnable = false;

    //ゲーム開始時に一度
    void Start()
    {
        player = GameObject.Find("Player");
    }

    //毎フレームに一度
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        if(isEnable==true)
        {
            if(Vector3.Distance(transform.position,player.transform.position)>2)
            {
                Vector3 playerDirection = player.transform.position;
                transform.LookAt(player.transform);
                moveDirection += transform.forward * 0.05f;
                transform.position += moveDirection;
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="Player")
        {
            isEnable = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.tag=="Player")
        {
            isEnable = false;
        }
    }
}

