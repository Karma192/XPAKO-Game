using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leveltext : MonoBehaviour
{
    public Text counterText;
    public XPbar xpb;

    public void Awake()
    {
        xpb = GameObject.FindObjectOfType<XPbar>();
    }

    void Update()
    {
        int level = xpb.level;
        counterText.text = level.ToString();
    }
}
