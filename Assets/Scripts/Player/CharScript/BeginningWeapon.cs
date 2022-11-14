using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningWeapon : MonoBehaviour
{
    private GameObject weaponF;
    private GameObject weapon;

    void Start()
    {
        weaponF = GameObject.Find("WeaponsFolder");
        weapon = weaponF.transform.Find("KeyboardKey").gameObject;
        weapon.SetActive(true);
    }
}
