using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RathalooseLife : MonoBehaviour
{
    
    public GameObject xpPrefabs;
    public EnemyStats ES;
    public double damageTaken;
    public bool HLS;

    private GameObject parent;
    private DeathManage dm;
    private DefineStatut ds;
    private float hp;

    void Awake()
    {
        ds = GameObject.FindObjectOfType<DefineStatut>();
        dm = GameObject.FindObjectOfType<DeathManage>();
    }

    void Update()
    {
        hp = ES.hp;

        if (damageTaken >= hp)
        {
            for (int i = 0; i < 5; i++)
            {
                DropXP();
            }
            Destroy (gameObject);
            dm.IncreaseDeaths();
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Bullet")
        {
            BulletsDamage BD = collisionInfo.gameObject.GetComponent<BulletsDamage>();
            damageTaken += BD.damage;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            BulletsDamage BD = collision.gameObject.GetComponent<BulletsDamage>();
            damageTaken += BD.damage;
        }
    }

    private void DropXP()
    {
        GameObject XP = Instantiate(xpPrefabs, gameObject.transform.position, transform.rotation);
    }
}