using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform target; // 따라갈 타겟의 트랜스 폼

    //총 위치값
    private float yDistance = 1.0f; // y값
    private float zDistance = -1.0f;// z값
    private float xDistance = 1.0f;// x값

    

    [Header("총구 섬광")][SerializeField] ParticleSystem ps_MuzzleFlash;
    [Header("총알 프리팹")] [SerializeField] GameObject go_Bullet_Prefab;
    [Header("총알 속도")] [SerializeField] float BulletSpeed;


    public void Fire()
    {
        float dir = (target.transform.localScale.x > 0.0f)? 1 : -1;

        //Debug.Log("발사");
        ps_MuzzleFlash.Play();

        go_Bullet_Prefab.transform.localScale = new Vector3(dir, 1, 1);

        var clone = Instantiate(go_Bullet_Prefab, ps_MuzzleFlash.transform.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(Vector2.one  * dir * BulletSpeed);
    }

    public void LockOnPlayer()
    {
       Vector3 newPos = target.position + new Vector3(xDistance, yDistance, -zDistance);
    }
    
    
}

