using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeHit : MonoBehaviour
{
    private int NB;
    private int randEffects;
    private GameObject[] player;
    private Player p;
    private StatusEffects SE;
    private Judge j;
    private WeaponStats WS;
    private BulletsDamage bd;

    private int tmp;
    private int lifeTime = 7;

    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        p = player[0].GetComponent<Player>();
        j = gameObject.transform.parent.GetComponent<Judge>();
        WS = gameObject.transform.parent.GetComponent<WeaponStats>();
        bd = gameObject.GetComponent<BulletsDamage>();
    }

    void Update ()
    {
        NB = j.numbers;

        if (tmp == lifeTime)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HitEffects(collision.gameObject);
        }
    }

    private void HitEffects (GameObject gm)
    {
        randEffects = Random.Range(1, NB+1);

        switch (randEffects)
        {
            case 1 :
                p.currentHealth -= 2;
                break;
            case 2 :
                //do a flip
                break;
            case 3 :
                gm.GetComponent<EnemyLifeSys>().damageTaken++;
                break;
            case 4 :
                gm.GetComponent<StatusEffectsEnemy>().ApplyBurn(6);
                break;
            case 5 :
                gm.GetComponent<StatusEffectsEnemy>().ApplyFreeze(6);
                break;
            case 6 :
                gm.GetComponent<StatusEffectsEnemy>().ApplyPoison(6);
                break;
            case 7 :
                WS.fireRate = WS.fireRate /2;
                break;
            case 8 :
                p.currentHealth += 5;
                break;
            case 9 :
                gm.GetComponent<EnemyLifeSys>().damageTaken += bd.damage;
                break;
        }
    }
}
