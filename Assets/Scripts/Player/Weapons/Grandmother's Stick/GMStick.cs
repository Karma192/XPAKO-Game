using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMStick : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public WeaponStats WS;

    private int tmp;
    private int currentLevel = 1;
    private int baseDamage;
    private GameObject[] player;
    private FindClosest FC;
    private GameObject[] Cam;
    private GameObject parent;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        Cam = GameObject.FindGameObjectsWithTag("MainCamera");
        FC = player[0].GetComponent<FindClosest>();
        parent = GameObject.Find("BulletsFolder");
        baseDamage = WS.damage;
    }

   
    void Update()
    {
        Aiming();
        Shooting();
        LevelUp();
    }

    private void Aiming ()
    {
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 lookDir = FC.FindClosestEnemy().transform.position - player[0].transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void Shooting ()
    {
        if (tmp == WS.fireRate)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            SetDamage(bullet);
            bullet.transform.SetParent(parent.transform);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

            tmp = 0;
        } else {
            tmp++;
        }
        
    }

    private void LevelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
            WS.damage = baseDamage + currentLevel;
        }
    }

    private void SetDamage (GameObject gm)
    {
        BulletsDamage BD = gm.GetComponent<BulletsDamage>();
        BD.damage = WS.damage;
    }
}
