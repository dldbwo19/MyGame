using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
   // public AudioSource booksound;

    public void PlayGame()
    {
        //PlayEffect();
        SceneManager.LoadScene(3);
    }
    public void Setting()
    {
       // PlayEffect();
        SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
        //PlayEffect();
        Application.Quit();
    }
}
