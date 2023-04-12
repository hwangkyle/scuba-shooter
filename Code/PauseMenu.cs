﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GamePaused == true){
                Resume();
            }
            else{
                Pause();
            }
        }
        
    }

    public void Resume(){
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;

    }

    void Pause(){
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu(){
        //Debug.Log("Load Main Menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame(){
        Debug.Log("Quitting...");
        //Application.Quit;

    }
     public void PlayGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }
}
