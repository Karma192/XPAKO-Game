using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    private GameObject xpmanager;
    private XPbar xpbar;

    void Start ()
    {
        xpmanager = GameObject.Find("XP bar");
        xpbar = xpmanager.GetComponent<XPbar>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "XP")
        {
            xpbar.xp += 2;
        }
    }
}
