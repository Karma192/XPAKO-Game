using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheeeeeeeese : MonoBehaviour
{
    private int lifeTime = 800;
    private int tmp;

    void Update ()
    {
        transform.Rotate(new Vector3(0f, 0f, 150) * Time.deltaTime);
        
        if (tmp == lifeTime)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject parent = GameObject.Find("Spart. Pistol");
            gameObject.transform.SetParent(parent.transform);
            Destroy(gameObject);
        } else {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
