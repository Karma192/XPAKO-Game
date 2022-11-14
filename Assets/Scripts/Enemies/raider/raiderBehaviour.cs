using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raiderBehaviour : MonoBehaviour
{
    public EnemyStats ES;
    

    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private int lifeTime = 1750;
    private int tmp;

    void Start()
    {
        player = GameObject.Find("MainChar");
        Vector3 pos = transform.position;
        transform.position = pos;
        rb = this.GetComponent<Rigidbody2D>();
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    void Update()
    {
        moveCharacter(movement);
        if (tmp == lifeTime)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * ES.speed * Time.deltaTime));
    }
}
