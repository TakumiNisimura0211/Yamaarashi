using UnityEngine;
using System.Collections;

public class box1 : MonoBehaviour {
    Rigidbody rb;
    public float jumpPower = 50;
    public bool jump = false;

    GameObject player;

    void Start () {
	
	}
	
	void Update () {
        player = GameObject.Find("Player");
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(jump==true)
            {
                //rb.AddForce(transform.up * 10, ForceMode.Impulse);
                player.GetComponent<Rigidbody>().AddForce(transform.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
}
