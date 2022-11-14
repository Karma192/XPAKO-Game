using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBalls : MonoBehaviour
{
    public GameObject[] ballsPrefabs;
    public WeaponStats WS;

    List<GameObject> balls = new List<GameObject>();
    List<int> IndexBalls = new List<int>();

    private GameObject[] player;
    private int currentLevel;
    private bool maxBalls = false;

    private GameObject spawn1 = null;
    private GameObject spawn2 = null;
    private GameObject spawn3 = null;
    private GameObject spawn4 = null;

    private Vector2 pos1;
    private Vector2 pos2;
    private Vector2 pos3;
    private Vector2 pos4;

    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        levelUp();
    }

    private void selectBalls ()
    {
        //menu de selection de new ball
        string choice = "neutral";
    
        switch (choice)
        {
            case "fire" :
                IndexBalls.Add(1);
                break;
            case "ice" :
                IndexBalls.Add(2);
                break;
            case "poison" :
                IndexBalls.Add(3);
                break;
            default:
                IndexBalls.Add(0);
                break;
        }
    }

    private void levelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
            WS.damage = currentLevel;
            if (currentLevel <= 4 && maxBalls == false)
            {
                selectBalls();
                newBalls(currentLevel);
                if (currentLevel >= 4)
                {
                    maxBalls = true;
                }
            }
        }
    }

    private void newBalls (int nbBalls)
    {
        switch (nbBalls)
        {
            case 1 :
                setPositions(nbBalls);
                spawn1 = Instantiate(ballsPrefabs[0], pos1, gameObject.transform.rotation);
                SetDamage(spawn1);
                spawn1.transform.SetParent(gameObject.transform);

                break;
            case 2 :
                setPositions(nbBalls);
                spawn1.transform.position = pos1;
                SetDamage(spawn1);
                spawn2 = Instantiate(ballsPrefabs[1], pos2, gameObject.transform.rotation);
                SetDamage(spawn2);
                spawn2.transform.SetParent(gameObject.transform);

                break;
            case 3 :
                setPositions(nbBalls);
                spawn1.transform.position = pos1;
                SetDamage(spawn1);
                spawn2.transform.position = pos2;
                SetDamage(spawn2);
                spawn3 = Instantiate(ballsPrefabs[2], pos3, gameObject.transform.rotation);
                SetDamage(spawn3);
                spawn3.transform.SetParent(gameObject.transform);

                break;
            case 4 :
                setPositions(nbBalls);
                spawn1.transform.position = pos1;
                SetDamage(spawn1);
                spawn2.transform.position = pos2;
                SetDamage(spawn2);
                spawn3.transform.position = pos3;
                SetDamage(spawn3);
                spawn4 = Instantiate(ballsPrefabs[3], pos4, gameObject.transform.rotation);
                SetDamage(spawn4);
                spawn4.transform.SetParent(gameObject.transform);

                break;
            default :
                break;
        }
    }

    private void setPositions (int nbBalls)
    {
        switch (nbBalls)
        {
            case 1 :
                pos1.x = player[0].transform.position.x;
                pos1.y = (float)(player[0].transform.position.y + 1);

                break;
            case 2 :
                pos1.x = player[0].transform.position.x;
                pos1.y = (float)(player[0].transform.position.y + 1);

                pos2.x = player[0].transform.position.x;
                pos2.y = (float)(player[0].transform.position.y - 1);

                break;
            case 3 :
                pos1.x = player[0].transform.position.x;
                pos1.y = (float)(player[0].transform.position.y + 1);

                pos2.x = (float)(player[0].transform.position.x - 0.9);
                pos2.y = (float)(player[0].transform.position.y - 0.44);

                pos3.x = (float)(player[0].transform.position.x + 0.9);
                pos3.y = (float)(player[0].transform.position.y - 0.44);

                break;
            case 4 :
                pos1.x = player[0].transform.position.x;
                pos1.y = (float)(player[0].transform.position.y + 1);

                pos2.x = player[0].transform.position.x;
                pos2.y = (float)(player[0].transform.position.y - 1);

                pos3.x = (float)(player[0].transform.position.x + 1);
                pos3.y = player[0].transform.position.y;

                pos4.x = (float)(player[0].transform.position.x - 1);
                pos4.y = player[0].transform.position.y;

                break;
        }
    }

    private void SetDamage (GameObject gm)
    {
        BulletsDamage BD = gm.GetComponent<BulletsDamage>();
        BD.damage = WS.damage;
    }
}