using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int killed;
    public float currentHealth;
    public float maxHealth;
    public int level;
    public int BulletSpeed;
    public int CoolDown;
    public int time = 1;

    public GameOver go;
    
    private HealthBar healthBar;
    private DeathManage dm;
    private PlayerStats PStats;
    private ObjectEffect oe;
    private EnemyStats es;
    private BulletStats bs;
    private Renderer rend;
    private IEnumerator coroutine;

    Color c;

    private void Start()
    {
        go = GameObject.Find("UI").gameObject.transform.Find("Canvas").gameObject.transform.Find("EndScreen").gameObject.GetComponent<GameOver>();
        healthBar = GameObject.Find("UI").gameObject.transform.Find("Canvas").gameObject.transform.Find("Health Bar").gameObject.GetComponent<HealthBar>();
        PStats = gameObject.GetComponent<PlayerStats>();
        oe = GameObject.FindObjectOfType<ObjectEffect>();
        dm = GameObject.FindObjectOfType<DeathManage>();

        maxHealth = PStats.hp;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    public void Update()
    {
        killed = dm.deaths;
        healthBar.SetHealth(currentHealth);
        maxHealth = PStats.hp;
        coroutine = GetInvulnerable(1);
        Die();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            es = collision.gameObject.GetComponent<EnemyStats>();
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            StartCoroutine(coroutine);
            TakeDamage(es.damage);
            es.hp -= oe.epine;
        }

        if (collision.collider.CompareTag("EnemyBullet"))
        {
            bs = collision.gameObject.GetComponent<BulletStats>();
            StartCoroutine(coroutine);
            TakeDamage(bs.damage);
        }

        if (collision.collider.CompareTag("Boss"))
        {
            StartCoroutine(coroutine);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(coroutine);
        }

        if (other.CompareTag("EnemyBullet"))
        {
            StartCoroutine(coroutine);
        }

        if (other.CompareTag("Boss"))
        {
            StartCoroutine(coroutine);
        }
    }

    public void TakeDamage(float dmg)
    {
        dmg -= PStats.armor;
        if (dmg > 0)
        {
            currentHealth -= dmg;
            healthBar.SetHealth(currentHealth);
        }
    }

    // public void SavePlayer()
    // {
    //     SaveSystem.SavePlayer(this);
    // }

    // public void LoadPlayer()
    // {
    //     PlayerData data = SaveSystem.LoadPlayer();
    //     level = data.level;
    //     currentHealth = data.health;
    //     Vector3 position;
    //     position.x = data.position[0];
    //     position.y = data.position[1];
    //     position.z = data.position[2];
    //     transform.position = position;
    // }

    public IEnumerator GetInvulnerable(int time)
    {
        Physics2D.IgnoreLayerCollision(9, 6, true); //enemy bullet layer
        Physics2D.IgnoreLayerCollision(9, 8, true); //enemy layer
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(time);
        Physics2D.IgnoreLayerCollision(9, 6, false);
        Physics2D.IgnoreLayerCollision(9, 8, false);
        c.a = 1f;
        rend.material.color = c;
    }

    private void Die ()
    {
        if (currentHealth <= 0)
        {
            go.gameover();
            Destroy(gameObject);
        }
    }
}
