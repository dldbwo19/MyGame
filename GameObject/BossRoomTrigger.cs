using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{
    PlayerMain playerMain;
    Vector3 bossSpawnPos;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject wall;
    bool bossEnable = true;

    void OnTriggerExit2D(Collider2D other)
    {
        playerMain = FindObjectOfType<PlayerMain>();
        bossSpawnPos = new Vector3(44.8f, -18f, 0);

        if(other.tag == "Player")
        {
            //BossRoomWaitTime();
            if (bossEnable)
            {
                Instantiate(boss, bossSpawnPos, Quaternion.identity);
                wall.SetActive(true);
                Invoke("BossRoomWaitTimeOver", 2.0f);
                //FindObjectOfType<AppSound>().BossBGMTrigger(0);
                bossEnable = false;
                this.gameObject.SetActive(false);
            }
        }
    }
    /*
    void BossRoomWaitTime()
    {
        playerMain.boosRoomWaitTime = true;
    }

    void BossRoomWaitTimeOver()
    {
        playerMain.boosRoomWaitTime = false;
    }
    */
}
