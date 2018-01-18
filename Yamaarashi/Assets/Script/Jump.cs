using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    Rigidbody rb;
    public float JumpPower = 250;
    public bool jump = false;
    GameObject player;
    public Vector3 AccelPowers = Vector3.up;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void OnTriggerEnter(Collider col)
    {
        if (jump)
        {
            //player.GetComponent<Rigidbody>().AddForce(transform.up * JumpPower * Time.deltaTime, ForceMode.Impulse);
            player.GetComponent<Rigidbody>().AddForce(AccelPowers.normalized * JumpPower * Time.deltaTime, ForceMode.Impulse);

        }
    }

}
