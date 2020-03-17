using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNeedle : MonoBehaviour
{
    [System.NonSerialized] BoxCollider2D shootTrigger;
    [System.NonSerialized] BoxCollider2D boxCollider2D;
    [System.NonSerialized] Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        shootTrigger = this.gameObject.GetComponentInChildren<BoxCollider2D>();
        boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
    }

    void SetDisableBoxCollider2D()
    {
        shootTrigger.enabled = false;
        boxCollider2D.enabled = false;
        Destroy(gameObject, 2.0f);
    }

    void SetDisableObject()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            rigidbody2D.velocity = new Vector2(0, 15);
            SetDisableBoxCollider2D();
        }
    }
}
