using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour {

    GameObject player;
    private 
        float AccelPower = 1.0f;

    public Vector3 AccelPowers = Vector3.zero;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update () {

    }
    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        player.GetComponent<Rigidbody>().AddForce(Vector3.up * AccelPower * Time.deltaTime, ForceMode.VelocityChange);
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(AccelPowers, ForceMode.VelocityChange);
    }

}
