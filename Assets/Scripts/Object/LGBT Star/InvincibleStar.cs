using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleStar : MonoBehaviour
{
    Renderer rend;
    Color c;
    public Player player;
    private IEnumerator coroutine;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        coroutine = player.GetInvulnerable(10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.StartCoroutine(coroutine);
            Destroy(gameObject);
        }
    }
}
