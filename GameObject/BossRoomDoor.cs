using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDoor : MonoBehaviour
{
    [SerializeField] GameObject gameObject;

    void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.collider.tag == "Grenade")
        {
            Destroy(gameObject);
        }
    }
}
