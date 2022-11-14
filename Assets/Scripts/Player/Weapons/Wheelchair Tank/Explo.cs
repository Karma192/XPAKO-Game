using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explo : MonoBehaviour
{
    private int lifeTime = 7;
    private int tmp;

    void Start ()
    {
        BulletsDamage bd = gameObject.GetComponent<BulletsDamage>();
        bd.damage = 5;
    }

    void Update ()
    {
        if (tmp == lifeTime)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<StatusEffectsEnemy>().ApplyBurn(10);
        }
    }
}
