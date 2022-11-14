using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCow : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject cowPrefab;
    public WeaponStats WS;

    private int tmp;
    private int currentLevel = 1;
    private int baseDamage;
    private Vector2 cowScale = new Vector2 (0, 0);
    private GameObject[] player;
    private FindClosest FC;
    private GameObject[] Cam;
    private GameObject parent;

    void Start()
    {
        cowScale.x = cowPrefab.transform.localScale.x;
        cowScale.y = cowPrefab.transform.localScale.y;
        player = GameObject.FindGameObjectsWithTag("Player");
        Cam = GameObject.FindGameObjectsWithTag("MainCamera");
        FC = player[0].GetComponent<FindClosest>();
        parent = GameObject.Find("BulletsFolder");
        baseDamage = WS.damage;
    }

    void Update()
    {
        Aiming();
        ForShooting();
        LevelUp();
    }

    private void Aiming ()
    {
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 lookDir = FC.FindClosestEnemy().transform.position - player[0].transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void ForShooting ()
    {
        if (tmp == WS.fireRate)
        {
            IsShooting();
            tmp = 0;
        } else {
            tmp++;
        }
        
    }

    private void IsShooting ()
    {
        GameObject cow = Instantiate(cowPrefab, firePoint.transform.position, firePoint.transform.rotation);
        SetDamage(cow);
        cow.transform.localScale = new Vector3 (cowScale.x, cowScale.y, cowPrefab.transform.localScale.z);
        cow.transform.SetParent(parent.transform);
        Rigidbody2D rb = cow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);
    }

    private void LevelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
            cowScale.x = 0.3f * (1 + (currentLevel * 0.2f));
            cowScale.y = 0.3f * (1 + (currentLevel * 0.2f));
            WS.damage = baseDamage + (currentLevel*2);
        }
    }

    private void SetDamage (GameObject gm)
    {
        BulletsDamage BD = gm.GetComponent<BulletsDamage>();
        BD.damage = WS.damage;
    }
}
