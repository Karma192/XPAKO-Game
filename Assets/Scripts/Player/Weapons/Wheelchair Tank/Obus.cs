using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obus : MonoBehaviour
{
    public GameObject explo;

    private int lifeTime = 300;
    private int tmp;

    void Start ()
    {
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        float angle = -45f;
        rb.rotation = angle;
    }

    void Update ()
    {
        if (tmp == lifeTime)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }

    void OnDestroy ()
    {
        GameObject explosion = Instantiate(explo, gameObject.transform.position, gameObject.transform.rotation);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
