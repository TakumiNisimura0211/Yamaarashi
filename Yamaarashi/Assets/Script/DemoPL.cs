using UnityEngine;
using System.Collections;

public class DemoPL : MonoBehaviour {

    float moveSpeed,maxSpeed,minSpeed;
    public DemoCA camera;
    //public bool stay = false;
    private Rigidbody rb;
    float inputHorizontal, inputVertical;

    AudioSource getSE;
    public Score ScoreScript;

    // Use this for initialization
    void Start () {
        moveSpeed = 20.0f;
        maxSpeed = 40.0f;
        minSpeed = 3.0f;
        this.gameObject.transform.forward = camera.transform.forward;

        rb = gameObject.GetComponent<Rigidbody>();

        getSE = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        //if(Input.GetKey(KeyCode.W))
        //{
        //    //rb.AddForce(transform.forward * maxSpeed);
        //    transform.position += transform.forward * moveSpeed;
        //}

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Jump"))
        {
            
        }

        this.gameObject.transform.forward = camera.transform.forward;
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

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Camera.main.transform.forward;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
            if(moveSpeed <= maxSpeed)
            moveSpeed += 0.1f;
        }
        else if(moveForward == Vector3.zero)
        {
            moveSpeed = 20.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //プレイヤーと衝突したとき
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            ScoreScript.ScoreUp();
            getSE.PlayOneShot(getSE.clip);
        }
    }
}
