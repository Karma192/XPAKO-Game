using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalls : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<StatusEffectsEnemy>().ApplyBurn(6);
        }
    }
}
