using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public FindClosest FC;

    private GameObject parent;
    private int tmp;
    private Rigidbody2D rb;

    void Start ()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        parent = GameObject.Find("BulletsFolder");
        gameObject.transform.SetParent(parent.transform);
        
        Aiming();
        if (tmp == 300)
        {
            Dash();
        }
        if (tmp == 600)
        {
            Die();
        } else {
            //Do a flip
            tmp++;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            parent = GameObject.Find("Gun Cow");
            gameObject.transform.SetParent(parent.transform);
        } else {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }

    void Aiming ()
    {
        Vector2 lookDir = FC.FindClosestEnemy().transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Dash ()
    {
        rb.AddForce(gameObject.transform.up * 250, ForceMode2D.Impulse);
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}