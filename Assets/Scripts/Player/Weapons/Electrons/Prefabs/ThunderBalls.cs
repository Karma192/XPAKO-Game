using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBalls : MonoBehaviour
{
    public GameObject spark;

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<StatusEffectsEnemy>().ApplyThunder(collision.transform, spark);
        }
    }
}
