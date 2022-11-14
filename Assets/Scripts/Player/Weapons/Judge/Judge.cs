using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public Transform hitpoints;
    public GameObject hits;
    public WeaponStats WS;
    public int numbers = 4;

    private int tmp;
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
            IsHitting();

            tmp = 0;
        } else {
            tmp++;
        }
    }

    private void IsHitting ()
    {
        GameObject hit = Instantiate(hits, hitpoints.transform.position, hitpoints.transform.rotation);
        SetDamage(hit);
        hit.transform.SetParent(gameObject.transform);
    }

    private void LevelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
            numbers = 3 + currentLevel;
        }
    }

    private void SetDamage (GameObject gm)
    {
        BulletsDamage BD = gm.GetComponent<BulletsDamage>();
        BD.damage = WS.damage;
    }
}
