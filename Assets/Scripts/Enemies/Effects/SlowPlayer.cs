using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    public int slow;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        PlayerMove playerSpeed = collision.collider.GetComponent<PlayerMove>();
        if (playerSpeed != null)
        {
            playerSpeed.Slow(slow);
        }
    }

}


