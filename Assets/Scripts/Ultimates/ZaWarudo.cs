using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaWarudo : MonoBehaviour
{
    public IEnumerator coroutine;
    private GameObject Spawn;
    private GameObject Boss;
    private SetList List;

    void Awake ()
    {
        List = GameObject.FindObjectOfType<SetList>();
    }

    public void Start()
    {
        Spawn = GameObject.Find("SpawnEnemy1");
        Boss = GameObject.Find("SpawnBoss");
    }
    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            foreach (GameObject go in List.List)            
            {
                go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
            Spawn.SetActive(false);
            ArrayList arr = new ArrayList();
            StartCoroutine(UNFREEZE(3, List.List));
        }
    }  
    
    IEnumerator UNFREEZE(float time, GameObject[] Objectlist)
    {
        yield return new WaitForSeconds(time);
        foreach (GameObject go in List.List)            
        {
            go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        Spawn.SetActive(true);
        gameObject.SetActive(false);
    }
}