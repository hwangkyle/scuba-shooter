using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Text hs;
    public static int highscore;
    private double highscoreupdate;

    
    // Start is called before the first frame update
    void Start()
    {
        hs = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hs.text = "High Score: " + highscore;
        highscoreupdate += Time.deltaTime;
        if (highscoreupdate >= 0.5 && highscore == Score.score - 1)
        {
            highscore += 1;
            highscoreupdate = 0;
        }
    }
}
