using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameClearButton : MonoBehaviour
{
    public void GotoLeaderboard()
    {
        SceneManager.LoadScene(4);
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene(0);
    }
}
