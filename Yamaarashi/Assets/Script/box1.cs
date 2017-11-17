using UnityEngine;
using System.Collections;

public class box1 : MonoBehaviour {
    Rigidbody rb;
    public float jumpPower = 10;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (gameObject.tag == "Player")
        {
            rb.AddForce(transform.up * 10, ForceMode.Impulse);
        }
    }
}
