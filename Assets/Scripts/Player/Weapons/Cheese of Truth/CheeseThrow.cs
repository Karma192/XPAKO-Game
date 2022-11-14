using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseThrow : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject cheesePrefab;
    public WeaponStats WS;

    private int tmp;
    private int currentLevel = 1;
    private int baseDamage;
    private Vector2 cheeseScale = new Vector2 (0, 0);
    private GameObject[] player;
    private FindClosest FC;
    private GameObject[] Cam;
    private GameObject parent;
    private float RandomAngle;

    void Start()
    {
        cheeseScale.x = cheesePrefab.transform.localScale.x;
        cheeseScale.y = cheesePrefab.transform.localScale.y;
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
        RandomAngle = Random.Range(-15f, 15f);
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 lookDir = FC.FindClosestEnemy().transform.position - player[0].transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f + RandomAngle;
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
        GameObject cheese = Instantiate(cheesePrefab, firePoint.transform.position, firePoint.transform.rotation);
        SetDamage(cheese);
        cheese.transform.localScale = new Vector3 (cheeseScale.x, cheeseScale.y, cheesePrefab.transform.localScale.z);
        cheese.transform.SetParent(parent.transform);
        Rigidbody2D rb = cheese.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

    }

    private void LevelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
            cheeseScale.x = cheeseScale.x * (1 + (currentLevel * 0.2f));
            cheeseScale.y = cheeseScale.y * (1 + (currentLevel * 0.2f));
            WS.damage = baseDamage + currentLevel;
        }
    }

    private void SetDamage (GameObject gm)
    {
        BulletsDamage BD = gm.GetComponent<BulletsDamage>();
        BD.damage = WS.damage;
    }
}
