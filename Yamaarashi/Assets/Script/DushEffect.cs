using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DushEffect : MonoBehaviour {

    private ParticleSystem particle;
    private bool flg;

	// Use this for initialization
	void Start () {
        particle = GetComponent<ParticleSystem>();
        flg = false;	
    }

    // Update is called once per frame
    void Update () {
        if(flg == false)
        {
            particle.Stop();
        }
        else if ( flg == true)
        {
            particle.Play();
        }
    }

    public void setFlg(bool f)
    {
        flg = f;
    }
}
