using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlayer : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject player;
    [Header("저장된 위치")] List<float> playerPos;

    public Vector3 playerDirection;
    float timer = 0;
    float savingTime = 0.1f;
    public float playerPosition;

    void Start()
    {
        playerPos = new List<float>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        playerDirection = player.transform.position;
        timer += Time.deltaTime;

        if (timer > savingTime)
        {
            if(playerPos.Count > 3)
            {
                playerPos.Remove(playerPos[0]);
            }
            playerPos.Add(player.transform.position.y + 0.5f);
            playerPosition = playerPos[0];
            timer = 0;
        }
    }
}
