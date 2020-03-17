using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour
{


    PlayerController playerCtrl;
    GunController gunCtrl;
    GrenadeController greCtrl;
    RespownPlayer respownPlayer;

    public Vector3 playerPos;
    bool possibleThrow = false;
    bool grenadeCheck;
    public bool boosRoomWaitTime = false;

    void Awake()
    {
        greCtrl = GetComponentInChildren<GrenadeController>();
        playerCtrl = GetComponent<PlayerController>();
        gunCtrl = GetComponentInChildren<GunController>();
        respownPlayer = FindObjectOfType<RespownPlayer>();

    }
    void Update()
    {
        playerPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        grenadeCheck = playerCtrl.CheckGrenade();
        gunCtrl.LockOnPlayer();

        if (!playerCtrl.activeSts)
        {
            if (Input.GetButtonDown("Respown"))
            {
                respownPlayer.Respown();
            }
            return;
        }
        float playerMv = Input.GetAxis("Horizontal");
        playerCtrl.ActionMove(playerMv);

        if (Input.GetButtonDown("Jump"))
        {
            playerCtrl.ActionJump();
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            gunCtrl.Fire();
        }

        if (Input.GetButton("Fire2") && grenadeCheck == true)
        {
            Debug.Log("던진다1");
            possibleThrow = greCtrl.ReadyGrenade(0.1f);
        }

        if (Input.GetButtonUp("Fire2") && possibleThrow == true && grenadeCheck == true)
        {
            Debug.Log("수류탄 투척");
            greCtrl.ThrowGrenade();
            playerCtrl.UsedGrenade();
            possibleThrow = true;

        }
        if (Input.GetButton("Respown"))
        {
            Destroy(this.gameObject);
            respownPlayer.Respown();
        }
        
    }
}