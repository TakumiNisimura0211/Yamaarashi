using UnityEngine;
using System.Collections;

public class DemoCA : MonoBehaviour
{

    private CourseBlock[] course;   //コースブロック
    private string[] name;          //コースブロックの名前登録
    private GameObject player;      //プレイヤー
    private Vector3 plus = new Vector3(0.0f, 2.0f, 0.0f);   //Ｙ座標を足す
    private Vector3 vec = new Vector3(0.0f, 0.0f, 0.0f);    //
    private Vector3 next = new Vector3(0.0f, 0.0f, 0.0f);   //
    short num;
    private float startTime;
    private float journeyLength;

    // Use this for initialization
    void Start()
    {
        course = new CourseBlock[] { null, null, null, null };
        name = new string[] { null, null, null, null };
        player = GameObject.FindGameObjectWithTag("Player"); startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //コースブロックと当たり続けている間
        //if (collision.gameObject.tag == "CourseBlockColider")
        //{
            short num = 0;
            Vector3 vec = new Vector3(0.0f, 0.0f, 0.0f);
            for (short i = 0; i < course.Length; i++)
            {
                if (course[i] != null)
                {
                    vec += course[i].GetVector();
                    num++;
                }
            }
            vec /= num;
            //this.transform.rotation = Quaternion.LookRotation(vec);
            this.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, Quaternion.LookRotation(vec), Time.time * 0.1f);
        //this.transform.position = player.transform.position + vec * -7 + plus;
        journeyLength = Vector3.Distance(this.gameObject.transform.position, (player.transform.position + vec * -7 + plus));
        float distCovered = (Time.time - startTime) * 0.1f;
        float fracJourney = distCovered / journeyLength;
        this.transform.position = Vector3.Lerp(this.gameObject.transform.position, (player.transform.position + vec * -7 + plus), fracJourney);
        //}
    }

    public void Enter(Collider collision)
    {
        //新しいコースブロックと接触したとき
        if (collision.gameObject.tag == "CourseBlockColider"){
            for (short i = 0; i < course.Length; i++)
            {
                if (name[i] == collision.gameObject.GetComponentInParent<CourseBlock>().gameObject.name)
                {
                    return;
                }
            }
            for (short i = 0; i < course.Length; i++){
                if (course[i] == null){
                    course[i] = collision.gameObject.GetComponent<CourseBlockColider>().GetComponentInParent<CourseBlock>();
                    name[i] = collision.gameObject.GetComponentInParent<CourseBlock>().gameObject.name;
                    break;
                }
            }
        }
    }

    public void Exit(Collider collision)
    {
        //コースブロックから出た時
        if (collision.gameObject.tag == "CourseBlockColider"){
            for (short i = 0; i < course.Length; i++){
                if (name[i] == collision.gameObject.GetComponentInParent<CourseBlock>().gameObject.name){
                    course[i] = null;
                    name[i] = null;
                    break;
                }
            }
        }
    }

    public void Stay(Collider collision)
    {
        //コースブロックと当たり続けている間
        if (collision.gameObject.tag == "CourseBlockColider")
        {
            short num = 0;
            Vector3 vec = new Vector3(0.0f,0.0f,0.0f);
            for (short i = 0; i < course.Length; i++)
            {
                if (course[i] != null)
                {
                    vec += course[i].GetVector();
                    num++;
                }
            }
            vec /= num;
            //this.transform.rotation = Quaternion.LookRotation(vec);
            this.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, Quaternion.LookRotation(vec), Time.time * 1.0f);
            //this.transform.position = player.transform.position + vec * -7 + plus;
            this.transform.position = Vector3.Lerp(this.gameObject.transform.position, (player.transform.position + vec * -7 + plus), Time.time * 1.0f);
        }
    }
}
