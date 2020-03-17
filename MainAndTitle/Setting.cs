using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    static float[] sli = new float[] { 1.0f, 1.0f, 1.0f };
    public Slider[] Sliders = new Slider[3];

    void Awake()
    {
        for (int i = 0; i < sli.Length; i++)
        {
            try
            {
                Sliders[i].value = sli[i];
            }
            catch (NullReferenceException)
            {
            }
        }
    }

    public void ALLVolume(float vol)
    {
        AudioListener.volume = vol;
        sli[0] = vol;
    }
    public void SetBgmVolume(float vol)
    {
        AppSound.instance.fm.SetVolume("BGM", vol);
        sli[1] = vol;
    }

    public void SetSEVolume(float vol)
    {
        AppSound.instance.fm.SetVolume("SE", vol);
        sli[2] = vol;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void BackButton()
    {
        SceneManager.LoadScene(1);
    }
}
