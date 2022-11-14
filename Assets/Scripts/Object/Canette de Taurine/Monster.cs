using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public DefineStatut ds;

    void Start()
    {
        ds = GameObject.FindObjectOfType<DefineStatut>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BoostSpeed();
            Destroy(gameObject);
        }
    }

    private void BoostSpeed()
    {
        ds.countS += 0.1f;
    }
}
