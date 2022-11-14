using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreeper : MonoBehaviour
{
    public GameObject[] CreeperPrefab;
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
            int DoWeSpawn = Random.Range(1,500);
            if (DoWeSpawn == 420){
                int Rand = Random.Range(1,64);
                Spawn(Rand);
            }
            
        } 
    }

    void Spawn (int nSpawn)
    {
        GameObject enemy = Instantiate(CreeperPrefab[0], SpPoints[nSpawn].position, SpPoints[nSpawn].rotation);
        enemy.transform.SetParent(parent.transform);
    }
}
