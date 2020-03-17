using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    public Transform target;

    [Header("수류탄 프리팹")] [SerializeField] GameObject grenade_Prefab;
    [Header("수류탄 파워")] [SerializeField] float GrenadePower;

    float force =1;
    
    public bool ReadyGrenade(float x)
    {
        force = force + x;
     
        if (force >= 10)
        {
            force = 10;
        }
        return true;

    }

    public void ThrowGrenade()
    {
        float a = Random.Range(-30f, 30f);

        float dir = (target.transform.localScale.x > 0.0f) ? 1f : -1f;

        Vector3 newPos = target.position + new Vector3(0.12f * dir, 0.2f, -1.0f);
        var clone = Instantiate(grenade_Prefab, newPos, Quaternion.Euler(0f, 0f, a));
        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir * force * 2, 2), ForceMode2D.Impulse);

        force = 1;
    }
}
