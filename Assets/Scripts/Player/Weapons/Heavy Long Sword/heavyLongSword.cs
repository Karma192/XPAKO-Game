using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyLongSword : MonoBehaviour
{
    public Transform[] hitpoints;
    public GameObject[] hits;
    public WeaponStats WS;

    private counterdeath kill;
    private int tmp;
    private int next = 0;
    private int baseDamage;
    private int currentLevel = 1;
    private GameObject[] player;
    private FindClosest FC;
    private int currentStep;

    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        FC = player[0].GetComponent<FindClosest>();
        baseDamage = WS.damage;
    }

    void Update ()
    {
        Aiming();
        Hit();
        LevelUp();
    }

    void Aiming ()
    {
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 lookDir = FC.FindClosestEnemy().transform.position - player[0].transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Hit ()
    {
        if (tmp == (int)WS.fireRate)
        {
            if (next == 0)
            {
                WS.damage = baseDamage + currentLevel;
                IsHitting(0);
                next = 1;
            } else if (next == 1) 
            {
                WS.damage = (int)((baseDamage + currentLevel) * 1.5);
                IsHitting(1);
                next = 0;
            }
            tmp = 0;
        } else {
            tmp++;
        }
    }

    private void IsHitting (int index)
    {
        GameObject hit = Instantiate(hits[index], hitpoints[index].transform.position, hitpoints[index].transform.rotation);
        SetDamage(hit);
        hit.transform.SetParent(gameObject.transform);
    }

    private void LevelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
            WS.damage = baseDamage + currentLevel;
            WS.fireRate = WS.fireRate * 0.85;
        }
    }

    private void SetDamage (GameObject gm)
    {
        BulletsDamage BD = gm.GetComponent<BulletsDamage>();
        BD.damage = WS.damage;
    }
}
