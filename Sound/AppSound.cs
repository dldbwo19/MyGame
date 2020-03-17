using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppSound : MonoBehaviour
{
  

    public static AppSound instance = null;
    //배경음
    [System.NonSerialized] public SoundManager fm;
    [System.NonSerialized] public AudioSource BGM_TITLE;
    [System.NonSerialized] public AudioSource BGM_PLAYGAME;
    [System.NonSerialized] public AudioSource BGM_BOSSROOM;
    [System.NonSerialized] public AudioSource BGM_BOSSDEAD;
    //효과음
    [System.NonSerialized] public AudioSource SE_MENU_OK;
    [System.NonSerialized] public AudioSource SE_ATK;
    [System.NonSerialized] public AudioSource SE_GRE;
    [System.NonSerialized] public AudioSource SE_GRE_EXP;
    [System.NonSerialized] public AudioSource SE_MOV_JUMP;
    [System.NonSerialized] public AudioSource SE_DEAD;
    [System.NonSerialized] public AudioSource SE_ITEM_GET;
    [System.NonSerialized] public AudioSource SE_CHECKPOINT;

    [System.NonSerialized] public AudioSource SE_BOSS_ATK;
    [System.NonSerialized] public AudioSource SE_BOSS_JUMP;
    [System.NonSerialized] public AudioSource SE_BOSS_DEAD;

    string sceneName = "non";
    bool bossBGM = false;
    bool bossDeadBGM = false;

    void Awake()
    {
        fm = GameObject.Find("SoundManager").GetComponent<SoundManager>();


        fm.CreateGroup("BGM");
        fm.SoundFolder = "Sounds/BGM/";
        BGM_TITLE = fm.LoadResourceSound("BGM", "Title");
        BGM_PLAYGAME = fm.LoadResourceSound("BGM", "PlayGame");
        BGM_BOSSROOM = fm.LoadResourceSound("BGM", "BoosRoom");
        BGM_BOSSDEAD = fm.LoadResourceSound("BGM", "BossDead");

        fm.CreateGroup("SE");
        fm.SoundFolder = "Sounds/SE/";
        SE_MENU_OK = fm.LoadResourceSound("SE", "SE_Menu_Ok");
        SE_ATK = fm.LoadResourceSound("SE", "SE_Atk");
        SE_GRE = fm.LoadResourceSound("SE", "SE_Gre");
        SE_GRE_EXP = fm.LoadResourceSound("SE", "SE_Gre_Exp");
        SE_MOV_JUMP= fm.LoadResourceSound("SE","SE_Mov_Jump");
        SE_DEAD = fm.LoadResourceSound("SE", "SE_Dead");
        SE_ITEM_GET = fm.LoadResourceSound("SE", "SE_Item_Get");
        SE_CHECKPOINT = fm.LoadResourceSound("SE", "SE_Cheakpoint");
        SE_BOSS_ATK = fm.LoadResourceSound("SE","SE_Boss_Atk");
        SE_BOSS_DEAD = fm.LoadResourceSound("SE", "SE_Boss_Dead");
        SE_BOSS_JUMP = fm.LoadResourceSound("SE", "SE_Boss_Jump");


        instance = this;

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "1.Title" && sceneName == "2.Main" && sceneName == "3.Setting")
            {
                BGM_TITLE.Play();
                fm.FadeInVolume(BGM_TITLE, 1.0f, 1.0f, true);
            }
            
            else if(sceneName == "4.PlayGame" && bossBGM == false && bossDeadBGM == false)
            {
                if (!BGM_TITLE.isPlaying)
                {
                    fm.Stop("BGM");
                    BGM_PLAYGAME.Play();
                    //fm.FadeOutVolume(BGM_TITLE, 0.0f, 1.0f, false);
                    fm.FadeInVolume(BGM_PLAYGAME, 1.0f, 1.0f, true);
                }
            }
            else if(sceneName == "4.PlayGame" && bossBGM == true)
            {
                fm.Stop("BGM");
                BGM_BOSSROOM.loop = true;
                BGM_BOSSROOM.Play();

            }
            else if(sceneName == "4.PlayGame" && bossDeadBGM == true)
            {
                fm.Stop("BGM");
                BGM_BOSSDEAD.Play();
                if (!BGM_BOSSDEAD.isPlaying)
                {
                    fm.Stop("BGM");
                    BGM_TITLE.Play();
                }
            }
            
        }
    }

    public void BossBGMTrigger(int num)
    {
        switch (num)
        {
            case 0:
                bossBGM = true;
                bossDeadBGM = false;
                break;
            case 1:
                bossBGM = false;
                bossDeadBGM = true;
                break;
            case 2:
                bossBGM = false;
                bossDeadBGM = false;
                break;
        }
    }
}

