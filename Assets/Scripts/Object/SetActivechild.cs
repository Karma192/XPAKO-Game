using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivechild : MonoBehaviour
{
    private GameObject[] Objectlist;
    private int nbchoice;
    List<int> list = new List<int>(); //  Declare list

    public void Update()
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

        SetTrue();
    }

    public void SetTrue()
    {
        foreach (GameObject go in Objectlist)
        {
            go.SetActive(true);
        }
    }
}