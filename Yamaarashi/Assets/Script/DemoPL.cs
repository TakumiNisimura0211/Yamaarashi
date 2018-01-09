using UnityEngine;
using System.Collections;

public class DemoPL : MonoBehaviour {

    float moveSpeed,maxSpeed,minSpeed;
    public DemoCA camera;
    public bool stay = false;

<<<<<<< HEAD
    AudioSource getSE;
    public Score ScoreScript;
    Animator animator;

    // Use this for initialization
    void Start () {
        moveSpeed = 20.0f;
        maxSpeed = 40.0f;
        minSpeed = 3.0f;
        this.gameObject.transform.forward = camera.transform.forward;

        rb = gameObject.GetComponent<Rigidbody>();

        getSE = GetComponent<AudioSource>();

        animator = this.GetComponent<Animator>();

    }
=======
	// Use this for initialization
	void Start () {
        moveSpeed = 0.5f;
        maxSpeed = 10.0f;
        minSpeed = 3.0f;
        this.gameObject.transform.forward = camera.transform.forward;
	}
>>>>>>> b8b7ad7b5ecde69dec6584126a73fc4ff540aa59
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed;
        }

        this.gameObject.transform.forward = camera.transform.forward;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "CourseBlockColider")
            camera.Enter(collision);
        else if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            ScoreScript.ScoreUp();
            getSE.PlayOneShot(getSE.clip);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "CourseBlockColider")
            camera.Exit(collision);
    }

    /*private void OnTriggerStay(Collider collision)
    {
        camera.Stay(collision);
    }*/
<<<<<<< HEAD

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
            //if(animator.GetBool("run") != true)
            //animator.SetBool("run", true);
        }
        else if(moveForward == Vector3.zero)
        {
            moveSpeed = 20.0f;
            //if (animator.GetBool("run") != false)
            //    animator.SetBool("run", false);
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        //プレイヤーと衝突したとき
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            ScoreScript.ScoreUp();
            getSE.PlayOneShot(getSE.clip);
        }
    }*/


=======
>>>>>>> b8b7ad7b5ecde69dec6584126a73fc4ff540aa59
}
