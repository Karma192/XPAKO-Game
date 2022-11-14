using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWeapon : MonoBehaviour
{
    public bool Taken = false;

    private Image I_Weapon;
    private Image S_Image;

    void Start ()
    {
        S_Image = gameObject.GetComponent<Image>();
    }

    public void SetImageWeapon (GameObject WP)
    {
        I_Weapon = WP.GetComponent<Image>();
        S_Image.sprite = I_Weapon.sprite;
        Color tempColor = S_Image.color;
        tempColor.a = 1f;
        S_Image.color = tempColor;
        Taken = true;
    }

    public void SuppImage ()
    {
        S_Image.sprite = null;
        Color tempColor = S_Image.color;
        tempColor.a = 0;
        S_Image.color = tempColor;
        Taken = false;
    }
}
