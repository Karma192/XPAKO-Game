using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCTank : MonoBehaviour
{
    public Transform firePoint;
    public GameObject obus;
    public WeaponStats WS;

    private int tmp;
    private int baseDamage;
    private int currentLevel = 1;
    private GameObject[] player;
    private FindClosest FC;
    private int currentStep;
    private GameObject parent;
    private int bonusArmor = 1;
    private float baseSpeed;
    private float baseArmor;

    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        FC = player[0].GetComponent<FindClosest>();
        baseDamage = WS.damage;
        parent = GameObject.Find("BulletsFolder");

        SetPlayerStats();
    }

    void OnDestroy()
    {
        ResetPlayerStats();
    }

    void Update ()
    {
        Aiming();
        Hit();
        LevelUp();
    }

    private void SetPlayerStats ()
    {
        PlayerMove pm = player[0].GetComponent<PlayerMove>();
        PlayerStats PS = player[0].GetComponent<PlayerStats>();
        baseSpeed = pm.playerSpeed;
        baseArmor = PS.armor;

        pm.playerSpeed = pm.playerSpeed * 0.9f;
        PS.armor = PS.armor + bonusArmor;
    }

    private void ResetPlayerStats ()
    {
        PlayerMove pm = player[0].GetComponent<PlayerMove>();
        PlayerStats PS = player[0].GetComponent<PlayerStats>();

        pm.playerSpeed = baseSpeed;
        PS.armor = baseArmor;
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
            IsShooting();

            tmp = 0;
        } else {
            tmp++;
        }
    }

    private void IsShooting ()
    {
        GameObject obusGM = Instantiate(obus, firePoint.transform.position, firePoint.transform.rotation);
        SetDamage(obusGM);
        obusGM.transform.SetParent(parent.transform);
        Rigidbody2D rb = obusGM.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);
    }

    private void LevelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
        }
    }

    private void SetDamage (GameObject gm)
    {
        BulletsDamage BD = gm.GetComponent<BulletsDamage>();
        BD.damage = WS.damage;
    }
}
