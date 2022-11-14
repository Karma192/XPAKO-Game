using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusrodah : MonoBehaviour
{
    public EnemyStats ES;
    private float ESpeed;
    public GameObject[] Objectlist;
    private int nbchoice;
    public IEnumerator coroutine;
    public float thrust ;
    public Rigidbody2D rb;
    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SetList();
            foreach (GameObject go in Objectlist)            
            {
                rb = go.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.up * thrust,  ForceMode2D.Impulse);
            }
            ArrayList arr = new ArrayList();
        }
    }
    
    private void SetList()
    {
        Objectlist = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Objectlist[i] = transform.GetChild(i).gameObject;
        }

        nbchoice = transform.childCount;
    }
}
