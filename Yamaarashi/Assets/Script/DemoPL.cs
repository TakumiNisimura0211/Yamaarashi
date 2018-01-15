using UnityEngine;
using System.Collections;

public class DemoPL : MonoBehaviour
{

    float moveSpeed, maxSpeed, minSpeed;
    public DemoCA camera;
    private Rigidbody rb;
    float inputHorizontal, inputVertical;

    AudioSource getSE;
    public Score ScoreScript;
    Animator animator;
    bool jump;

    // Use this for initialization
    void Start()
    {
        moveSpeed = 20.0f;
        maxSpeed = 40.0f;
        minSpeed = 3.0f;
        this.gameObject.transform.forward = camera.transform.forward;
        jump = false;

        rb = gameObject.GetComponent<Rigidbody>();

        getSE = GetComponent<AudioSource>();

        animator = this.GetComponent<Animator>();
        animator.Play("Standing@loop");
    }

    // Update is called once per frame
    void Update()
    {

        //if(Input.GetKey(KeyCode.W))
        //{
        //    //rb.AddForce(transform.forward * maxSpeed);
        //    transform.position += transform.forward * moveSpeed;
        //}

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (jump != true && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * 300);
        }

        this.gameObject.transform.forward = camera.transform.forward;
    }

    private void OnTriggerEnter(Collider collision)
    {
            Debug.Log("coin");
        //カメラ
        if (collision.gameObject.tag == "CourseBlockColider")
            camera.Enter(collision);
        //コイン
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            ScoreScript.ScoreUp();
            getSE.PlayOneShot(getSE.clip);
        }
        camera.Enter(collision);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ジャンプ
        if (collision.gameObject.tag == "StageColider")
        {
            jump = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        camera.Exit(collision);
    }

    /*private void OnTriggerStay(Collider collision)
    {
        camera.Stay(collision);
    }*/
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "StageColider")
        {
            jump = true;
        }
    }

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
            if (animator.GetBool("Run") == false)
                animator.SetBool("Run", true);
            transform.rotation = Quaternion.LookRotation(moveForward);
            if (moveSpeed <= maxSpeed)
                moveSpeed += 0.1f;
            //if(animator.GetBool("run") != true)
            //animator.SetBool("run", true);
        }
        else if (moveForward == Vector3.zero)
        {
            if (animator.GetBool("Run") == true)
                animator.SetBool("Run", false);
            moveSpeed = 20.0f;
            //if (animator.GetBool("run") != false)
            //    animator.SetBool("run", false);
        }
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

