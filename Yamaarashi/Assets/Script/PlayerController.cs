using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float Speedes = 2.0f;
    public float MaxSpeed = 10.0f;

    public Rigidbody rb;
    public Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);

    bool jumpFlg = true;

    //Rigidbody rb;

    //public bool isUsecameraDirection;

    //public float moveSpeed;
    //public float moveSpeedMultiplier;

    //public GameObject mainCamera;

    //float horizontalInput;
    //float verticalInput;

    void Start () {
        rb = GetComponent<Rigidbody>();
        //rb = GetComponent<Rigidbody>();

        //if(mainCamera==null)
        //{
        //    mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //}

    }

    void Update () {
        velocity.z -= 0.9f;
        if (velocity.z <= 0)
        {
            velocity.z = 0.0f;
        }

        if (Input.GetKey(KeyCode.L))
        {
            while (Speedes <= MaxSpeed)
            {
                Speedes += 0.5f;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        velocity.x = Input.GetAxis("Horizontal") * Time.deltaTime * Speedes;
        velocity.z = Input.GetAxis("Vertical") * Time.deltaTime * Speedes;



        rb.MovePosition(transform.position + velocity * Time.deltaTime);
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
    }

    //void FixedUpdate()
    //{
    //    Vector3 moveVector = Vector3.zero;

    //    //if(isUsecameraDirection)
    //    //{
    //    //    Vector3 cameraForwad = mainCamera.transform.forward;
    //    //    Vector3 cameraRight = mainCamera.transform.right;
    //    //    cameraForwad.y = 0.0f;
    //    //    cameraRight.y = 0.0f;

    //    //    moveVector = moveSpeed * (cameraRight.normalized * horizontalInput + cameraForwad.normalized * verticalInput);
    //    //}
    //    //else
    //    //{
    //    //    moveVector.x = moveSpeed * horizontalInput;
    //    //    moveVector.z = moveSpeed * verticalInput;
    //    //}

    //    //rb.AddForce(moveSpeedMultiplier * (moveVector - rb.velocity));
    //}


    void jump()
    {
        rb.AddForce(Vector3.up * 500);
    }
}
