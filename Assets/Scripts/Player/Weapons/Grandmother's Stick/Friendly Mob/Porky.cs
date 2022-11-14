using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porky : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float speed;
    private GameObject parent;

    void Start()
    {
        Vector3 pos = transform.position;
        transform.position = pos;
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = 3.5f;
    }

    void Update()
    {
        target = gameObject.GetComponent<FindClosest>().FindClosestEnemy();
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
