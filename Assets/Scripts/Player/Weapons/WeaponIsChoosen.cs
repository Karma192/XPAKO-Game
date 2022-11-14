using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIsChoosen : MonoBehaviour
{
    private GameObject[] Slots;

    void Awake ()
    {
        Slots = GameObject.FindGameObjectsWithTag("slotInventory");
    }

    void OnEnable ()
    {
        foreach(GameObject sl in Slots) 
        {
            ShowWeapon SW = sl.GetComponent<ShowWeapon>();
            if (SW.Taken == false)
            {
                SW.SetImageWeapon(gameObject);
                break;
            } else {
                //do a flip
            }
        }
    }

    void OnDisable ()
    {
        foreach(GameObject sl in Slots) 
        {
            ShowWeapon SW = sl.GetComponent<ShowWeapon>();
            Image imgSL = sl.GetComponent<Image>();
            if (imgSL.sprite == gameObject.GetComponent<Image>().sprite)
            {
                SW.SuppImage();
                break;
            } else {
                //do a flip
            }
        }
    }
}
