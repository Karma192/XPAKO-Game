using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisbee : MonoBehaviour
{
    private bool back;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float dist;

    void Start()
    {
        player = GameObject.Find("MainChar");
        Vector3 pos = transform.position;
        transform.position = pos;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        transform.Rotate(new Vector3(0f, 0f, 200) * Time.deltaTime);
        dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        
        if (back)
        {
            Return();

            if ((int)dist == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && back == false)
        {
            GameObject parent = GameObject.Find("Bat-Frisbee");
            gameObject.transform.SetParent(parent.transform);
            back = true;
        } else {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }

    private void Return ()
    {
        GameObject parent = GameObject.Find("BulletsFolder");
        gameObject.transform.SetParent(parent.transform);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        movement = direction;

        rb.MovePosition((Vector2)transform.position + (direction * 20 * Time.deltaTime));
    }
}
