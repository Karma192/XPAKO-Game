using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillProjectile : MonoBehaviour
{
    private int lifeTime = 700;
    private int tmp;

    public float speed;
    Rigidbody2D BP;
    GameObject target;
    
    void Start()
    {
        BP = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        BP.velocity = new Vector2(moveDir.x, moveDir.y);
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
            Destroy(gameObject);
        }
    }
}
