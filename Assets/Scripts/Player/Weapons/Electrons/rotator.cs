using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public WeaponStats WS;
    private GameObject[] player;

    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update ()
    {
        gameObject.transform.position = player[0].transform.position;
        transform.Rotate(new Vector3(0f, 0f, (float)WS.bulletSpeed) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
