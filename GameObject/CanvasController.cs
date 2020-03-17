using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    static int playerLife =3;
    [SerializeField] GameObject bossSilder;
    [SerializeField] Slider bossHpSlider;
    [SerializeField] Text playerLifeText;
    [SerializeField] Text playerLifeText2;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameClear;
    [SerializeField] Image panel;

    string strPlayerLife;
   
    void Start()
    {
        gameClear = GameObject.FindGameObjectWithTag("GameClearUI");
        gameOverText = GameObject.FindGameObjectWithTag("GameOverUI");
        bossSilder = GameObject.FindGameObjectWithTag("BossHp");

        bossSilder.SetActive(false);
        gameClear.SetActive(false);
        gameOverText.SetActive(false);
        panel.enabled = false;

        strPlayerLife = playerLife.ToString();
        playerLifeText.GetComponent<Text>().text = strPlayerLife;
    }
    //boss door trigger 
    public void OnBossHpSlider()
    {
        bossSilder.SetActive(true);
    }

    //Connected
    public void OffBossHpSlider()
    {
        bossSilder.SetActive(false);
    }
    
    //Connected
    public void SetBossHpSlider(float damage)
    {
        bossHpSlider.value -= damage;
    }

    //Connected
    public void GameClear()
    {
        gameClear.SetActive(true);
        playerLifeText2.GetComponent<Text>().text = strPlayerLife;
        panel.enabled = true;
        RespownPlayer.firstStart = true;
    }

    //Connected
    public void GameOver()
    {
        panel.enabled = true;
        gameOverText.SetActive(true);
        playerLife--;
        strPlayerLife = playerLife.ToString();
        playerLifeText.GetComponent<Text>().text = strPlayerLife;        
    }
}

