using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Vector3 vel = new Vector3(0.0f, 0.0f, 0.0f);
    public float speed = 1.0f;

    public Rigidbody rb;
    public Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);

    private Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        velocity.z -= 0.9f;
        if (velocity.z <= 0)
        {
            velocity.z = 0.0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            velocity.z = speed*10.0f;
        }
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }
}

