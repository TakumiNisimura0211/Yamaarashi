using UnityEngine;
using System.Collections;

public class DemoCA : MonoBehaviour
{

    //private CourseBlockColider colider;
    //private GameObject parent,child;
    private CourseBlock[] course;
    private GameObject player;
    private Vector3 plus = new Vector3(0.0f, 2.0f, 0.0f);

    // Use this for initialization
    void Start()
    {
        course = new CourseBlock[] { null, null, null, null };
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "CourseBlockColider"){
            for (short i = 0; i < course.Length; i++){
                if (course[i] == null){
                    course[i] = collision.gameObject.GetComponent<CourseBlockColider>().GetComponentInParent<CourseBlock>();
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "CourseBlockColider"){
            for (short i = 0; i < course.Length; i++){
                if (course[i] == collision.gameObject){
                    course[i] = null;
                    break;
                }
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.tag == "CourseBlockColider")
        {
            Debug.Log("get");
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
