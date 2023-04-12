using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instUI;
    public void PlayGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Instructions(){
        instUI.SetActive(true);
        
    }
}
