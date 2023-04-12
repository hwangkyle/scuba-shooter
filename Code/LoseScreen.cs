using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public GameObject loseUI;
    public DiverMove diver;
    public GameObject slider;
    public GameObject s;
    public GameObject t;
    public GameObject sco;
    public GameObject hisco;
    public Text finalscore;
    public Text finalscore2;
    public static double highscore = 0;
    //private Text h;
    //private Text sco;
    // Start is called before the first frame update
    void Start()
    {
        //h = GetComponent<Text>();
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.score > highscore)
        {         
            highscore = Score.score;
            //hisco = "HighScore: "+highscore;
        }

        

     if (diver.currentAir <= 0)
        {
            MyCoroutine();
            finalscore.text = Score.score.ToString();
            finalscore2.text = Score.hiscore.ToString();
            //sco.GetComponent<Text>() = Score.sco;
            //Debug.Log(Score.score);
            //WaitForSeconds(1f);
            loseUI.SetActive(true);
            slider.SetActive(false);
            s.SetActive(false);
            t.SetActive(false);
            //sco.SetActive(true);
            //hisco.SetActive(true);
            //l.text = score;

            //pauseUI.SetActive(false);
            //transform.position = new Vector3(transform.position.x, -6, transform.position.z);
            
        }
    }
    public void PlayGame()
   {
       SceneManager.LoadScene("Scooba Shooter");
   }
    public void LoadMenu(){
        //Debug.Log("Load Main Menu");
        SceneManager.LoadScene("Main Menu");
    }

}
