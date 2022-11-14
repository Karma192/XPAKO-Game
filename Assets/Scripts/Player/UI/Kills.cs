using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kills : MonoBehaviour
{
    private int kills;
    public Text killText;

    void OnEnable ()
    {
        kills = GameObject.Find("GameManager").GetComponent<DeathManage>().deaths;

        if (kills < 0)
        {
            kills = 0;
        }

        killText.text = string.Format("{0}", kills);
    }
}
