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
    bool jump,end;
    Vector3 nonFowrad;

    // Use this for initialization
    void Start()
    {
        moveSpeed = 10.0f;
        maxSpeed = 30.0f;
        minSpeed = 10.0f;
        this.gameObject.transform.forward = camera.transform.forward;
        jump = true;
        end = false;
        nonFowrad = new Vector3(0, 0, 0);

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
        //入力
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        //ジャンプ
        if (jump != false && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * 300);
            animator.SetBool("Jump", false);
            jump = false;
        }

        //this.gameObject.transform.forward = camera.transform.forward;
    }

    private void OnTriggerEnter(Collider collision)
    {
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
        if (collision.gameObject.tag == "Coin+")
        {
            Destroy(collision.gameObject);
            ScoreScript.SscoreUp();
            getSE.PlayOneShot(getSE.clip);
        }
        if(collision.gameObject.tag == "Wave")
        {
            end = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ジャンプ
        if (collision.gameObject.tag == "StageColider")
        {
            jump = true;
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
            if (moveSpeed < maxSpeed)
                moveSpeed += 1.0f;
            nonFowrad = moveForward;
        }
        else if (moveForward == Vector3.zero)
        {
            if (animator.GetBool("Run") == true)
                animator.SetBool("Run", false);
            if (nonFowrad != new Vector3(0, 0, 0) && transform.rotation != Quaternion.LookRotation(nonFowrad))
                transform.rotation = Quaternion.LookRotation(nonFowrad);
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

