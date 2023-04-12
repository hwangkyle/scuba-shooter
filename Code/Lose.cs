using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Lose : MonoBehaviour
{
    
    public DiverMove diver;
    public Text l;
    //bool Losr = false;
    private float timer = 0;
    //public static int airValue = DiverMove.airSupply;
    //public GameObject loseUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Text>();
        diver = GameObject.FindWithTag("Player").GetComponent<DiverMove>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4)
        {
            l.text = "  ";
        }
        if (DiverMove.ammoCount <= 0 && diver.currentAir > 0)
        {
            l.text = "OUT OF AMMO";
        }
        if (diver.currentAir <= 0)
        {
            //l.text = "YOU LOSE";
            l.text = "Score: " + Score.score;
            Time.timeScale = 0;
            //WaitForSeconds(1f);
            //loseUI.SetActive(true);
            
        }
    }
}
