using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    FollowingPlayer followingplayer;
    Vector3 targetPosition;
    Vector3 startPosition;

    float speed;
    float distanceLength;
    float startTime;
    float randomPos;

    void Start()
    {
        speed = Random.Range(2.0f, 4.0f);
        

        followingplayer = FindObjectOfType<FollowingPlayer>();
        targetPosition = followingplayer.playerDirection;
        startPosition = followingplayer.transform.position;

        if((targetPosition.x >= 40f))
        {
            randomPos = Random.Range(-8.0f, -10.0f);
        }
        if ((targetPosition.x) >= 38f)
        {
            randomPos = Random.Range(-6.0f, -8.0f);
        }
        else if((targetPosition.x) < 38f)
        {
            randomPos = Random.Range(-4.0f, -6.0f);
        }

        startPosition = startPosition + new Vector3(-1.0f, 0, 0);

        startTime = Time.time;

        distanceLength = Vector3.Distance(startPosition, targetPosition);
        targetPosition = new Vector3(targetPosition.x + randomPos, targetPosition.y, targetPosition.z);
    }
    void Update()
    {
        float disCovered = (Time.time - startTime) * speed;
        float franJourney = disCovered / distanceLength;
        transform.position = Vector3.Lerp(startPosition, targetPosition, franJourney);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
