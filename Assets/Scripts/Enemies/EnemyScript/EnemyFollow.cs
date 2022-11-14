using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public EnemyStats ES;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        player = GameObject.Find("MainChar");
        Vector3 pos = transform.position;
        transform.position = pos;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * ES.speed * Time.deltaTime));
    }
}
