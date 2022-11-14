using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //ici c'est pour le code commun a tous les boss

    void OnDestroy ()
    {
        GameObject.Find("GameManager").GetComponent<DeathManage>().deathsBoss++;
    }
}
