using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Vector3 vel = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField]
    public float speed = 1.0f;
    public Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);
    public Rigidbody rb;
    public DemoCA camera;

    AudioSource getSE;
    public Score ScoreScript;


    void Start () {
        getSE = GetComponent<AudioSource>();
	}
	
	void Update () {
        vel = transform.position;

        if (Input.GetKey(KeyCode.S))
        {
            vel.z += 0.5f * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vel.z -= 0.5f * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel.x -= 0.5f * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x += 0.5f * speed;
        }

        transform.position = vel;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 250);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        camera.Enter(collision);
    }

    private void OnTriggerExit(Collider collision)
    {
        camera.Exit(collision);
    }

    /*private void OnTriggerStay(Collider collision)
    {
        camera.Stay(collision);
    }*/
    void OnCollisionEnter(Collision collision)
    {
        //コインと衝突したとき
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            ScoreScript.ScoreUp();
            getSE.PlayOneShot(getSE.clip);
        }
        if(collision.gameObject.tag=="Enemy")
        {

            Destroy(collision.gameObject,0.5f);
        }
    }

}

