using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour {
    // ポストエフェクトシェーダー入りのマテリアル 
    public Material[] postEffectMat;
    //画面切り替え 
    const float fadeMax = 64.0f;
    float fadeCount = 0.0f;
    static bool fadeFlag = true;
    public float value = 0.0f;
    bool deadfld;
    bool flg;
    int i;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update () {
        if (deadfld == true || flg==true)
        {
            fadeFlag = true;
            value = 3.0f;
        }
        else if (deadfld == false || flg == false)
        {
            fadeFlag = false;
            value = -3.0f;
        }

        //Clamp(float value,float min,float max)
        //与えられた最小 float 値と最大 float 値の範囲に値を制限します。
        fadeCount = Mathf.Clamp(fadeCount + value / fadeMax, 0.0f, 1.0f);

        postEffectMat[i].SetFloat("_FadeCount", fadeCount);

	}
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, postEffectMat[i]);
    }
    public void setDFlg(bool f)
    {
        deadfld = f;
        i = 0;
    }

    public void setFlg(bool f)
    {
        flg = f;
        i = 1;
    }
    
    public void SetfadeFlag(bool flg)
    {
        fadeFlag = flg;
    }
}
