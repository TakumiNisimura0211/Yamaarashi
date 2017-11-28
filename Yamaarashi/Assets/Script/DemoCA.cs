using UnityEngine;
using System.Collections;

public class DemoCA : MonoBehaviour
{

    //private CourseBlockColider colider;
    //private GameObject parent,child;
    private CourseBlock[] course;
    private string[] name;
    private GameObject player;
    private Vector3 plus = new Vector3(0.0f, 2.0f, 0.0f);
    private Vector3 vec = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 next = new Vector3(0.0f, 0.0f, 0.0f);
    short num;

    // Use this for initialization
    void Start()
    {
        course = new CourseBlock[] { null, null, null, null };
        name = new string[] { null, null, null, null };
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        num = 0;
        vec = new Vector3(0.0f, 0.0f, 0.0f);
        //Debug.Log("get");
        for (short i = 0; i < course.Length; i++)
        {
            if (course[i] != null)
            {
                vec += course[i].GetVector();
                num++;
            }
        }
        if (vec != next)
        {
            vec /= num;
            //course = collision.gameObject.GetComponent<CourseBlockColider>().GetComponentInParent<CourseBlock>();
            this.transform.rotation = Quaternion.LookRotation(vec);
            this.transform.position = player.transform.position + vec * -7 + plus;
        }
    }

    public void Enter(Collider collision)
    {
        if (collision.gameObject.tag == "CourseBlockColider"){
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
        
        if (collision.gameObject.tag == "CourseBlockColider")
        {
            //Debug.Log("get");
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
            //course = collision.gameObject.GetComponent<CourseBlockColider>().GetComponentInParent<CourseBlock>();
            this.transform.rotation = Quaternion.LookRotation(vec);
            this.transform.position = player.transform.position + vec * -7 + plus;
            
        }
    }
}
