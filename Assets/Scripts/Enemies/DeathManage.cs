using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManage : MonoBehaviour
{
    public int deaths;
    public int HLSKills;
    public int CreeperKilled;
    public int deathsBoss;

    public void IncreaseDeaths()
    {
        deaths++;
    }
}
