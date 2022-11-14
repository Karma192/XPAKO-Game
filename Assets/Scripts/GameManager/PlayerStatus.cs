using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private DefineStatut ds;
    private GameObject player;
    private PlayerMove pm;
    private PlayerStats PS;

    void Awake()
    {
        player = GameObject.Find("MainChar");
        PS = player.GetComponent<PlayerStats>();
        ds = GameObject.FindObjectOfType<DefineStatut>();
        PS.moveSpeed = ds.countS;
        PS.coefSpeedWeapon = ds.countSW;
        PS.coefDamage = ds.countD;
        PS.hp = ds.hp;
        PS.armor = ds.armor;
    }
}
