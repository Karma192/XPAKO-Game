using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    public int value;
    public int xp;

    private bool go;
    private float speed;
    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private int tmp;
    private int lifetime = 18000;

    void Start()
    {
        player = GameObject.Find("MainChar");
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        Die();
    }

    private void FixedUpdate()
    {
        if (go == true)
        {
            moveCharacter (movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        speed = player.GetComponent<PlayerMove>().playerSpeed * 3f;
        rb.MovePosition((Vector2) transform.position + (direction * speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            go = true;
        }
        else
        {
            Physics2D
                .IgnoreCollision(gameObject.GetComponent<Collider2D>(),
                collision.gameObject.GetComponent<Collider2D>());
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            xp += 5;
            Destroy (gameObject);
        }
        else
        {
            Physics2D
                .IgnoreCollision(gameObject.GetComponent<Collider2D>(),
                collisionInfo.gameObject.GetComponent<Collider2D>());
        }
    }

    private void Die ()
    {
        if (tmp == lifetime)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }
}
