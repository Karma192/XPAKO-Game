using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDice : MonoBehaviour
{
    public DefineStatut ds;
    public XPbar xp;
    public Player player;

    public void Awake()
    {
        ds = GameObject.FindObjectOfType<DefineStatut>();
        xp = GameObject.FindObjectOfType<XPbar>();
        player = GameObject.FindObjectOfType<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PartyDice();
            Destroy(gameObject);
        }
    }

    public void PartyDice()
    {
        float randomNumber = Random.Range(1, 7);
        if (randomNumber == 1)
        {
            Debug.Log("1");
            xp.xp = 0;
        }
        if (randomNumber == 2)
        {
            Debug.Log("2");
            player.currentHealth -= 30;
        }
        if (randomNumber == 3)
        {
            Debug.Log("3");
            Example();
        }
        if (randomNumber == 4)
        {
            Debug.Log("4");
            ds.countS = (float)(ds.countS * 1.25);
        }
        if (randomNumber == 5)
        {
            Debug.Log("5");
            player.currentHealth += 30;
        }
        if (randomNumber == 6)
        {
            Debug.Log("6");
            xp.level++;
        }
    }

    private void Example()
    {
        ds.countS = (float)(ds.countS * 1.25);
        Invoke("Reset", 3);
    }

    private void Reset()
    {
        ds.countS = (float)(ds.countS * 0.75);
    }
}
