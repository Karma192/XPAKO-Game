using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public bool randomEnemy;
    public int group;
    public GameObject[] enemyPrefabs;
    public int TimeForSpawn;
    public bool spawn = true;

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
        if (tmp == TimeForSpawn && spawn == true)
        {
            if (randomEnemy)
            {
                for (int i = 0; i < group; i++)
                {
                    int randE = Random.Range(0, enemyPrefabs.Length);
                    Spawn(randE);
                }
            } else {
                for (int i = 0; i < group; i++)
                {
                    Spawn(0);
                }
            }

            tmp = 0;
        } else {
            tmp++;
        }
    }

    void Spawn (int enemyIndex)
    {
        int randPoints = Random.Range(1, SpPoints.Length);
        GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], SpPoints[randPoints].position, SpPoints[randPoints].rotation);
        enemy.transform.SetParent(parent.transform);
    }
}
