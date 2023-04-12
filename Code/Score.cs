using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text s;
    public static int score;
    public static int hiscore = 0;
    private double scoreupdate;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<Text>();
        score = 0;
        scoreupdate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        s.text = "Score: " + score;
        scoreupdate += Time.deltaTime;
        if (scoreupdate >= .5)
        {
            score = score + 1;
            scoreupdate = 0;
        }


        if (score > hiscore)
        {         
            hiscore = score;
            //hisco = "HighScore: "+highscore;
        }
    }
}
