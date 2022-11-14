using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private int lifeTime = 700;
    private int tmp;

    public float speed;
    GameObject target;
    Rigidbody2D bulletRB;
    
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg +180f;
        bulletRB.rotation = angle;
    }

    void Update() 
    {
        if (tmp == lifeTime)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<StatusEffects>().ApplyBurn(6);
            Destroy(gameObject);
        }
    }
}
