using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreeperBehaviour : MonoBehaviour
{
    public EnemyStats ES;
    public GameObject[] creeperBoom;

    private GameObject player;
    
    private Rigidbody2D rb;
    private Vector2 movement;
    private float distance;

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
        distance = Vector3.Distance (player.transform.position, transform.position);
        if (distance <= 1.2)
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * ES.speed * Time.deltaTime));
    }

    void OnDestroy ()
    {
        GameObject enemy = Instantiate(creeperBoom[0], transform.position, transform.rotation);
        GameObject gameManager = GameObject.Find("GameManager");
        DeathManager DM = gameManager.GetComponent<DeathManager>();
        // DM.CreeperKilled++;
    }
}
