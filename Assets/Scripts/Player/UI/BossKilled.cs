using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossKilled : MonoBehaviour
{
    private int kills;
    public Text killBText;

    void OnEnable ()
    {
        kills = GameObject.Find("GameManager").GetComponent<DeathManage>().deathsBoss;

        if (kills < 0)
        {
            kills = 0;
        }

        killBText.text = string.Format("{0}", kills);
    }
}
