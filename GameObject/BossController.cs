using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("보스 총알")]
    [SerializeField] GameObject bossBulletPrefeb;
    [Header("보스 HP")]
    [SerializeField] float hp;
    float playerVector3;
    Vector3 direction;

    float bossHpMax;
    float bossHp;
    float randomFire;
    float timer;
    bool firstTime = true;
    FollowingPlayer followingPlayer;
    CanvasController canvasController;

    void Start()
    {
        bossHpMax = hp;
        bossHp = bossHpMax;
        followingPlayer = GetComponentInChildren<FollowingPlayer>();
        canvasController = FindObjectOfType<CanvasController>();
        canvasController.OnBossHpSlider();
    }

    void Update()
    {
        randomFire = Random.Range(1.0f, 3.0f);
        playerVector3 = followingPlayer.playerPosition;
        direction = followingPlayer.playerDirection;
        if (!firstTime)
        {
            timer += Time.deltaTime;
            if (Mathf.Abs(randomFire - timer) <= 0.5f)
            {
                BulletFire();
                timer = 0;
            }

            if (Mathf.Abs(playerVector3 - transform.position.y) > 0.1)
            {
                MoveBoss();
            }
        }
        
        if (firstTime)
        {
            if (Mathf.Abs(playerVector3 - transform.position.y) > 0.1)
            {
                MoveBossFirstPos();
            }
        }
        
        /*
        else if (Mathf.Abs(playerVector3 - transform.position.y) <= 0.1)
        {
            timer = 0;
        }
        */
    }

    void MoveBoss()
    {
        if ((playerVector3 - transform.position.y) > 0.1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 2.5f;
        }
        else if ((playerVector3 - transform.position.y) < -0.1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 2.0f;
        }
    }

    void BulletFire()
    {
        var clone = Instantiate(bossBulletPrefeb, new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z), transform.rotation);
    }

    bool SetHP(float damage)
    {
        canvasController.SetBossHpSlider(damage);
        bossHp = bossHp - damage;
        return (bossHp <= 0);
    }

    void BossDead()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 15.0f;
        Invoke("GameClear", 2.0f);
        Destroy(gameObject, 2.0f);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "PlayerArmBullet")
        {
            bool gameClear = SetHP(1.0f);
            if(gameClear)
            {
                BossDead();
            }
        }
        if(coll.gameObject.tag == "Grenade")
        {
            bool gameClear = SetHP(5.0f);
            if (gameClear)
            {
                BossDead();
            }
        }
    }

    void GameClear()
    {
        //var canvasController = FindObjectOfType<CanvasController>();
        canvasController.GameClear();
        canvasController.OffBossHpSlider();
    }
    
    void MoveBossFirstPos()
    {
        float bossFirstPos = -9.65f;

        if(Mathf.Abs(bossFirstPos - transform.position.y) < 0.1)
        {
            firstTime = false;
            return;
        }

        if ((bossFirstPos - transform.position.y) > 0.1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 2.5f;
        }
        else if ((bossFirstPos - transform.position.y) < -0.1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 2.0f;
        }
    }

}
