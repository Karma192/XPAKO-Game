using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactuarBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    public EnemyStats ES;

    private int tmp;
    private GameObject[] player;
    private GameObject parent;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        parent = GameObject.Find("BulletsFolder");
    }

   
    void Update()
    {
        Aiming();
        Shooting();
    }

    private void Aiming ()
    {
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 lookDir = player[0].transform.position - this.gameObject.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void Shooting ()
    {
        if (tmp == ES.fireRate)
        {
            int shoot = Random.Range(1, 10);
            if (shoot == 9)
            {
            GameObject bullet = Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            bullet.transform.SetParent(parent.transform);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(this.gameObject.transform.up * (float)ES.bulletSpeed, ForceMode2D.Impulse);
            }
            tmp = 0;
        } else {
            tmp++;
        }
        
    }
}
