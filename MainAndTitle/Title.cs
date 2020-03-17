using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{
    

    public void Movemenu()
    {

        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Movemenu();
        }
    }
}
