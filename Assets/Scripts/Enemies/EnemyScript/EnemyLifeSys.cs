using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSys : MonoBehaviour
{
    public GameObject xpPrefabs;
    public EnemyStats ES;
    private ObjectList ol;
    public double damageTaken;

    public bool HLS;
    public bool GMS = false;

    private DeathManage dm;
    private DefineStatut ds;
    private float hp;

    void Awake()
    {
        ol = GameObject.FindObjectOfType<ObjectList>();
        ds = GameObject.FindObjectOfType<DefineStatut>();
        dm = GameObject.FindObjectOfType<DeathManage>();
    }

    void Update()
    {
        hp = ES.hp;

        if (damageTaken >= hp)
        {
            if (HLS == true)
            {
                dm.HLSKills++;
            }
            DropXP();
            Destroy(gameObject);
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            BulletsDamage BD = collider.gameObject.GetComponent<BulletsDamage>();
            damageTaken += BD.damage;
        }
    }

    private void DropXP()
    {
        GameObject XP = Instantiate(xpPrefabs, gameObject.transform.position, transform.rotation);
        ol.DropItem(gameObject.transform);
    }
}
