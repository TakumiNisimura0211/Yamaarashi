using UnityEngine;
using System.Collections;

public class CourseBlock : MonoBehaviour {

    public GameObject start,end;
	
    public Vector3 GetVector()
    {
        //start = this.transform.FindChild("Start").GetComponent<GameObject>();
        //end = this.transform.FindChild("End").GetComponent<GameObject>();

            Vector3 target = end.transform.position - start.transform.position;
        Vector3 mag = target.normalized;

        return mag;
        //return target;
    }

    public Quaternion GetQuaternion()
    {
        return Quaternion.FromToRotation(start.transform.position,end.transform.position);
    }
}
