using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smashTriangle : MonoBehaviour
{
    private GameObject ultimateFolder;
    
    void Start ()
    {
        ultimateFolder = GameObject.Find("Ultimates");
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EffectSmashT();
            Destroy(gameObject);
        } else {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }

    private void EffectSmashT ()
    {
        GameObject[] l = ultimateFolder.GetComponent<SetList>().List;
        int index = Random.Range(0, l.Length);
        l[index].gameObject.SetActive(true);
    }
}
