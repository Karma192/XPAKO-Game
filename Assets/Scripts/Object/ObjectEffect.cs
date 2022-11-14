using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEffect : MonoBehaviour
{
    public float epine;

    private GameObject p;
    private PlayerStats PS;
    private int a = 0;
    private XPbar xp;
    private Player player;
    private ObjectList ol;

    public void Start()
    {
        p = GameObject.Find("MainChar");
        PS = p.GetComponent<PlayerStats>();
        xp = GameObject.FindObjectOfType<XPbar>();
        player = GameObject.FindObjectOfType<Player>();
        ol = GameObject.FindObjectOfType<ObjectList>();
    }

    public void LvlDown()
    {
        PS.coefDamage++;
    }

    public void Sebum()
    {
        PS.armor = PS.armor * 1.05f;
    }

    public void loiz()
    {
        PS.hp += 20;
    }

    public void Epine()
    {
        epine = PS.armor;
    }

    public void SaintTriangle()
    {
        a++;
        if (a == 2)
        {
            PS.armor++;
            PS.coefDamage++;
            PS.moveSpeed++;
        }
    }

    public void trefle()
    {
        ol.a -= 10;
    }
}
