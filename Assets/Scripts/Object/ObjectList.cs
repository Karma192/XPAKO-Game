using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    private GameObject[] Objectlist;
    private int nbchoice;
    List<int> list = new List<int>(); //  Declare list
    private GameObject parent;
    public FindClosest FC;
    public int a;

    public void Awake()
    {
        parent = GameObject.Find("ObjectSpawnFolder");
    }

    public void Start()
    {
        Objectlist = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            Objectlist[i] = transform.GetChild(i).gameObject;
        }

        nbchoice = transform.childCount;

        for (int n = 0; n < nbchoice; n++) //  Populate list
        {
            list.Add(n);
        }

        SetFalse();

        a = 101;
    }

    public void SetFalse()
    {
        foreach (GameObject go in Objectlist)
        {
            go.SetActive(false);
        }
    }

    public void DropItem(Transform trans)
    {
        float randomNumber = Random.Range(1, a);
        if (randomNumber == 2)
        {
            int index = Random.Range(0, list.Count);
            int j = list[index];
            GameObject Object = Instantiate(Objectlist[j], trans.position, trans.rotation);
            Object.transform.SetParent(parent.transform);
        }
        else { }
    }
}
