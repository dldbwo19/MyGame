using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("피격 이펙트")]
    [SerializeField] GameObject gunHitEffect;
    [Header("총알 데미지")]
    [SerializeField] int damage;

    RespownPlayer respownPlayer;

    void Start()
    {
        Destroy(gameObject, 2f);
        respownPlayer = FindObjectOfType<RespownPlayer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        ContactPoint2D contactPoint = other.contacts[0];

        var clone = Instantiate(gunHitEffect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));

        Destroy(clone, 0.2f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SaveObject")
        {
            respownPlayer.SetRespownPoint();
            Destroy(this.gameObject);
        }
    }
}
