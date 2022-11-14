using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    private GameObject[] player;

    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        transform.position = player[0].transform.position;
    }
}
