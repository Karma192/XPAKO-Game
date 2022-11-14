using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPassif : MonoBehaviour
{
    public bool Taken = false;

    private Image I_Passif;
    private Image S_Image;

    void Start ()
    {
        S_Image = gameObject.GetComponent<Image>();
    }

    public void SetImagePassif (GameObject Pa)
    {
        I_Passif = Pa.GetComponent<Image>();
        S_Image.sprite = I_Passif.sprite;
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
