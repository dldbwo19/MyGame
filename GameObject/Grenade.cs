using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [Header("피격 이팩트")]
    [SerializeField] GameObject grenadeHitEffect;
    [Header("피격 이팩트")]
    [SerializeField] GameObject grenadeRange;
    [Header("수류탄 데미지")]
    [SerializeField] int damage;

    void Awake()
    {
        Invoke("SetTrigger", 2.8f);
        Invoke("PlayParticle", 2.8f);
        Destroy(this.gameObject, 3.0f);
    }
    void SetTrigger()
    {
        grenadeRange.SetActive(true);
    }
    void PlayParticle()
    {
        var clone = Instantiate(grenadeHitEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(clone, 0.35f);
    }
}
