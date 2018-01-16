using UnityEngine;


public class Score : MonoBehaviour
{

    public int Scores = 00;
    public GUIText scoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = Scores.ToString();
        scoreText.text = "Score : " + Scores.ToString();
    }

    public void ScoreUp()
    {
        Scores++;
    }
    public void SscoreUp()
    {
        Scores += 5;
    }
}
