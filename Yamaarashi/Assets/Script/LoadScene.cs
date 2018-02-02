using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public PostEffect pe;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKey)
        //{
        //    SceneManager.LoadScene("Stage_2");
        //}
        pe.setFlg(true);
        changeNext();
    }
    void changeNext()
    {
        if (Time.timeSinceLevelLoad > 4.0f)
        {
            SceneManager.LoadScene("Stage_2", LoadSceneMode.Single);
        }
    }
}

