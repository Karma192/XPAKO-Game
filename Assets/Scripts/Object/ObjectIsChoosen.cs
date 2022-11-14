using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectIsChoosen : MonoBehaviour
{
    private GameObject[] Slots;

    void Awake ()
    {
        Slots = GameObject.FindGameObjectsWithTag("slotPassif");
    }

    void OnEnable ()
    {
        foreach(GameObject sl in Slots) 
        {
            ShowPassif SP = sl.GetComponent<ShowPassif>();
            if (SP.Taken == false)
            {
                SP.SetImagePassif(gameObject);
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
            ShowPassif SP = sl.GetComponent<ShowPassif>();
            Image imgSL = sl.GetComponent<Image>();
            if (imgSL.sprite == gameObject.GetComponent<Image>().sprite)
            {
                SP.SuppImage();
                break;
            } else {
                //do a flip
            }
        }
    }
}
