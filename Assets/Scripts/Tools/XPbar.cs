using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public DeathManage dm;
    public Player player;
    private XP XPS;
    public int xp;
    public int level = 1;

    void Awake()
    {
        XPS = GameObject.FindObjectOfType<XP>();
        dm = GameObject.FindObjectOfType<DeathManage>();
        player = GameObject.FindObjectOfType<Player>();
        SetMaxXP();
    }

    void Update()
    {
        GainXP();
        SetXP();
    }

    public void SetMaxXP()
    {
        fill.color = gradient.Evaluate(1f);
    }

    public void SetXP()
    {
        slider.value = xp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void GainXP()
    {
        if (xp == 100 || xp > 100)
        {
            xp = 0;
            level++;
        }
    }
}
