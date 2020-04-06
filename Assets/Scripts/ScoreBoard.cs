using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    
    [SerializeField] int beingAlive = 1;
    int score;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        SendMessage("BeingAlive");
    }

    public void ScoreHit(int scoreIncrease)
    {
        print("hello");
        score = score + scoreIncrease;
        scoreText.text = score.ToString();
    }

    public void BeingAlive()
    {
        // I have added code!
        print("hello33");
        score = score + beingAlive;
        scoreText.text = score.ToString();
        //SendMessage("timingPoints");
    }
}
