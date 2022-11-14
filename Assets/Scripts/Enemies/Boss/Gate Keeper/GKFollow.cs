using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKFollow : MonoBehaviour
{
    private GameObject player;

    private Rigidbody2D rb;

    private Vector2 movement;

    public float Enemyspeed;

    public float timeValue = 0;

    public float Timefixed;

    public Transform enemyGFX;

    private SpriteRenderer spriteRenderer;

    private PlayerMove pm;

    void Start()
    {
        pm = GameObject.FindObjectOfType<PlayerMove>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = transform.position;
    }

    public void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;

        moveGK (movement);
        this.spriteRenderer.flipX =
            player.transform.position.x < this.transform.position.x;
    }

    void moveGK(Vector2 direction)
    {
        rb
            .MovePosition((Vector2) transform.position +
            (direction * pm.playerSpeed * 0.9f) * Time.deltaTime);
    }
}
