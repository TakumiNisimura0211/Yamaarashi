using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectTest : MonoBehaviour {
    public Material postEffectMat;
    const float fadeMax = 64.0f;
    public float fadeCount = 64.0f;
    bool fadeFlag = false;
    float value = 0.0f;
    bool flg;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        value = -2.0f;

        fadeCount = Mathf.Clamp(fadeCount + value / fadeMax, 0.0f, 1.0f);

        postEffectMat.SetFloat("_FadeCount", fadeCount);
    }
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, postEffectMat);
    }
}
