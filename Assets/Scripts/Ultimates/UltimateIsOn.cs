using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateIsOn : MonoBehaviour
{
    private GameObject[] Slot;
    private ShowUltimate SU;
    private Image imgSL;

    void Awake ()
    {
        Slot = GameObject.FindGameObjectsWithTag("slotUlti");
        SU = Slot[0].GetComponent<ShowUltimate>();
        imgSL = Slot[0].GetComponent<Image>();
    }

    void OnEnable ()
    {
        if (SU.Taken == false)
        {
            SU.SetImageUltimate(gameObject);
        }
    }

    void OnDisable ()
    {
        if (imgSL.sprite == gameObject.GetComponent<Image>().sprite)
        {
            SU.SuppImage();
        }
    }
}
