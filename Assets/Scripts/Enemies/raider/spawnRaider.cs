using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRaider : MonoBehaviour
{
    public GameObject[] RaiderPrefab;
    public int TimeForSpawn;
    public int groupSize;
    public bool spawn = true;
    public float timeValue;
    public float Timefixed;
    
    // private int tmp;
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
        if (Timefixed >= TimeForSpawn && spawn == true)
        {
            int DoWeSpawn = Random.Range(1,100);
            if (DoWeSpawn == 69){
                int Rand = Random.Range(1,64);
                int Rand2 = Rand;
                for (int i = 0; i < groupSize; i++)
                {
                    Rand += Random.Range(0, groupSize);
                    Spawn(Rand);
                    Rand = Rand2;
                }
                spawn = false;
            }
            
        } 
    }

    void Spawn (int nSpawn)
    {
        GameObject enemy = Instantiate(RaiderPrefab[0], SpPoints[nSpawn].position, SpPoints[nSpawn].rotation);
        enemy.transform.SetParent(parent.transform);
    }
}

