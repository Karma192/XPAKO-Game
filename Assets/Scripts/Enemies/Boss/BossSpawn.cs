using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Rathaloose;
    public GameObject Keeper;
    public GameObject[] BossPrefabs;
    public float timeValue;
    public float Timefixed;
    public bool one = true;

    private int deaths;
    private bool Rspawned = false;
    private bool Kspawned = false;
    private DeathManage dm;
    private GameObject parent;
    private Vector2 posSpawn;
    private Transform[] SpPoints;

    void Awake() 
    {
        dm = GameObject.FindObjectOfType<DeathManage>();
    }

    void Start() 
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

        if (Timefixed == 180 && one == true)
        {
            Spawn(0);
            one = false;
        }

        SpawnRathaloose();
    }

    void Spawn (int enemyIndex)
    {
        int randPoints = Random.Range(0, SpPoints.Length);
        GameObject enemy = Instantiate(BossPrefabs[enemyIndex], SpPoints[randPoints].position, SpPoints[randPoints].rotation);
        enemy.transform.SetParent(parent.transform);
        DisableSpawners DS = enemy.GetComponent<DisableSpawners>();
        if (DS != null)
        {
            DS.spawners = gameObject.transform.parent.gameObject;
        }
    }

    void SpawnRathaloose ()
    {
        if (dm.HLSKills >= 20 && Rspawned == false)
        {
            Rspawned = true;
            int randPoints = Random.Range(0, SpPoints.Length);
            GameObject enemy = Instantiate(Rathaloose, SpPoints[randPoints].position, SpPoints[randPoints].rotation);
            enemy.transform.SetParent(parent.transform);
            DisableSpawners DS = enemy.GetComponent<DisableSpawners>();
            DS.spawners = gameObject.transform.parent.gameObject;
        }
    }

    void SpawnKeeper ()
    {
        if (dm.CreeperKilled >= 250 && Kspawned == false)
        {
            Kspawned = true;
            int randPoints = Random.Range(0, SpPoints.Length);
            GameObject enemy = Instantiate(Keeper, SpPoints[randPoints].position, SpPoints[randPoints].rotation);
            enemy.transform.SetParent(parent.transform);
            DisableSpawners DS = enemy.GetComponent<DisableSpawners>();
            DS.spawners = gameObject.transform.parent.gameObject;
        }
    }
}
