using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {
    Animator animator;
    private bool isEnable = false;
    public GameObject player;
    bool moveFlg = false;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.M))
        {
            animator.SetBool("moveFlg",true);
        }
        if(Input.GetKey(KeyCode.N))
        {
            animator.SetBool("New Bool", false);
        }
    }
}
