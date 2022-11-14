using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmongUs : MonoBehaviour
{
    public FindClosest FC;
    private float time;
    public GameObject AmongusUI;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AmongusUI.SetActive(true);
            KillSus();
            Destroy(gameObject, 2);
        }
    }

    private void KillSus()
    {
        float randomNumber = Random.Range(5, 10);
        time = 1;
        for (int i = 0; i < randomNumber; i++)
        {
            Invoke("Kill", time);
            time += 0.1f;
        }
        Invoke("resume", 1);
    }

    private void Kill()
    {
        Destroy(FC.FindClosestEnemy());
    }

    private void resume()
    {
        AmongusUI.SetActive(false);
    }
}
