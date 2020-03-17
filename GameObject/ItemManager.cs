using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("리스폰 아이템")]
    [SerializeField] GameObject item;
    [Header("리스폰 쿨타임")]
    [SerializeField] float RendSeconds;
    [Header("라이프 타임")]
    [SerializeField] float HideSeconds;

    PlayerController playerCtrl;

    Vector3 itemPos;

    Animator animator;

    int jumpCount;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void SetRendSprite()
    {
        item.SetActive(true);
    }

    void SetHideSprite()
    {
        item.SetActive(false);
    }

    void SetSprite()
    {
        Invoke("SetHideSprite", HideSeconds);
        Invoke("SetRendSprite", RendSeconds);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerCtrl = FindObjectOfType<PlayerController>();
            if (this.gameObject.name == "JumpPad")
            {
                playerCtrl.jumpCount = 1;
                SetSprite();
            }
            if(this.gameObject.tag == "JumpRock")
            {
                animator.SetTrigger("Touch");
                Destroy(item, 0.5f);
            }

            if(this.gameObject.name == "Grenade")
            {  
                playerCtrl.GetGrenade();
                //playerMain.SetPossibleThrow();
                Debug.Log("수류탄 먹음");
                Destroy(this.gameObject);
            }

        }
    }


}
    
