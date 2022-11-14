using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rathaloosefollow : MonoBehaviour
{
    private GameObject player;

    private Rigidbody2D rb;

    private Vector2 movement;

    private SpriteRenderer spriteRenderer;

    public float Enemyspeed;

    public float timeValue = 0;

    public float Timefixed;

    public Transform enemyGFX;

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

        if (timeValue >= 0)
        {
            Timefixed = Mathf.Round(timeValue += Time.deltaTime);
        }
        else
        {
            timeValue = 0;
        }

        if (Timefixed == 5)
        {
            moveRathaloose (movement);
        }

        if (Timefixed == 8)
        {
            Timefixed = 0;
            timeValue = 0;
        }

        this.spriteRenderer.flipX =
            player.transform.position.x < this.transform.position.x;
    }

    void moveRathaloose(Vector2 direction)
    {
        rb
            .MovePosition((Vector2) transform.position +
            (direction * pm.playerSpeed * 12f) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player currentHealth = collision.collider.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<StatusEffects>() != null)
        {
            other.GetComponent<StatusEffects>().ApplyPoison(6);
        }
    }
}
