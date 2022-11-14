using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetList : MonoBehaviour
{
    public GameObject[] List;
    private int nbchoice;
    public IEnumerator coroutine;

    public void Update()
    {
        List = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            List[i] = transform.GetChild(i).gameObject;
        }
        nbchoice = transform.childCount;
    }
}
