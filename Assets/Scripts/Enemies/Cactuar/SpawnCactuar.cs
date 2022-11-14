using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCactuar : MonoBehaviour
{
    public GameObject[] CactuarPrefab;
    public int TimeForSpawn;
    public bool spawn = true;
    public float timeValue;
    public float Timefixed;

    private int tmp;
    private GameObject parent;
    private Vector2 posSpawn;
    private Transform[] SpPoints;

    void Start ()
    {
        parent = GameObject.Find("EnemiesFolder");
        SpPoints = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (timeValue >= 0f)
        {
            Timefixed = Mathf.Round(timeValue += Time.deltaTime);
        }

        else
        {
            timeValue = 0f;
        }

        if (Timefixed == TimeForSpawn && spawn == true)
        {
            for (int i = 1; i < 64; i++)
            {
                Spawn(i);
            }
            // tmp = 0;
            spawn = false;
        } else {
            tmp++;
        }
    }

    void Spawn (int nSpawn)
    {
        if (nSpawn % 2 == 0){
            GameObject enemy = Instantiate(CactuarPrefab[0], SpPoints[nSpawn].position, SpPoints[nSpawn].rotation);
            enemy.transform.SetParent(parent.transform);
        }
    }
}
