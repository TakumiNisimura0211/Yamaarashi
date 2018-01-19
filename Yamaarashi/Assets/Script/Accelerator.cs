using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour {

    GameObject player;
    public float AccelPower = 1.0f;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update () {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * AccelPower * Time.deltaTime, ForceMode.VelocityChange);
            col.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,10,30), ForceMode.VelocityChange);
        }
    }
}
