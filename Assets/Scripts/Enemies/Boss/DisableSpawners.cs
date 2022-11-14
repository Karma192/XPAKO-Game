using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawners : MonoBehaviour
{
    public GameObject spawners;

    void Start ()
    {
        spawners.SetActive(false);
    }

    void OnDestroy ()
    {
        spawners.SetActive(true);
    }
}
