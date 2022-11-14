using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject[] bulletPrefab;
    public WeaponStats WS;

    List<int> Index = new List<int>();

    private int tmp;
    private int currentLevel = 1;
    private int baseDamage;
    private int nbBullet = 1;
    private GameObject[] player;
    private FindClosest FC;
    private GameObject[] Cam;
    private GameObject parent;
    private int index;
    private int currentStep = 0;

    void Start ()
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
        ChooseAndShoot();
        LevelUp();
    }

    void Aiming()
    {
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 lookDir = FC.FindClosestEnemy().transform.position - player[0].transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void ChooseAndShoot()
    {
        if(tmp == WS.fireRate)
        {
            switch (nbBullet)
            {
                case 2 :
                    Index.Clear();
                    Index.Add(2);
                    Index.Add(5);                    

                    StartCoroutine("ForShoot");

                    break;

                case 3 :
                    int randComb = Random.Range(0, 5);
                    switch (randComb)
                    {
                        case 0 :
                            Index.Clear();
                            Index.Add(0);
                            Index.Add(1);
                            Index.Add(2);

                            StartCoroutine("ForShoot");

                            break;
                        case 1 :
                            Index.Clear();
                            Index.Add(1);
                            Index.Add(5);
                            Index.Add(2);

                            StartCoroutine("ForShoot");

                            break;
                        case 2 :
                            Index.Clear();
                            Index.Add(1);
                            Index.Add(3);
                            Index.Add(7);

                            StartCoroutine("ForShoot");

                            break;
                        case 3 :
                            Index.Clear();
                            Index.Add(6);
                            Index.Add(7);
                            Index.Add(0);

                            StartCoroutine("ForShoot");

                            break;
                        case 4 :
                            Index.Clear();
                            Index.Add(1);
                            Index.Add(3);
                            Index.Add(6);

                            StartCoroutine("ForShoot");

                            break;
                        default :
                            Index.Clear();
                            for (int i = 0; i < nbBullet; i++)
                            {
                                int randBullet = Random.Range(0, bulletPrefab.Length);
                                Index.Add(randBullet);
                            }

                            StartCoroutine("ForShoot");

                            break;
                    }

                    break;
                default:
                    Index.Clear();
                    for (int i = 0; i < nbBullet; i++)
                    {
                        int randBullet = Random.Range(0, bulletPrefab.Length);
                        Index.Add(randBullet);
                    }

                    StartCoroutine("ForShoot");

                    break;
            }

            tmp = 0;
        } else {
            tmp++;
        }
    }

    void LevelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
            WS.damage = baseDamage + currentLevel;

            if ((currentLevel % 4) == 0)
            {
                if ((currentLevel / 4) <= 3)
                {
                    nbBullet = 1 + (currentLevel/4);
                }
            }
        }
    }

    IEnumerator ForShoot ()
    {
        float time = 0;

        for (int i = 0; i < nbBullet; i++)
        {
            Invoke("SetIndex", time);
            Invoke("IsShooting", time);
            currentStep = i;
            yield return new WaitForSeconds(time);
            if (time == 0)
            {
                time += 0.05f;
            }
        }
    }

    private void SetIndex ()
    {
        index = Index[currentStep];
    }

    private void IsShooting ()
    {
        GameObject bullet = Instantiate(bulletPrefab[index], firePoint.transform.position, firePoint.transform.rotation);
        SetDamage(bullet);
        bullet.transform.SetParent(parent.transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);
    }

    private void SetDamage (GameObject gm)
    {
        BulletsDamage BD = gm.GetComponent<BulletsDamage>();
        BD.damage = WS.damage;
    }
}