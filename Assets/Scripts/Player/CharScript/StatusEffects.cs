using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{
    private Player player;
    private List<int> burnTickTimes = new List<int>();
    private List<int> poisonTickTimes = new List<int>();

    void Start() 
    {
        player = GetComponent<Player>();
    }

    public void ApplyBurn(int ticks)
    {
        burnTickTimes.Add(ticks);
        StartCoroutine(Burn());
    }

    public void ApplyPoison(int ticks)
    {
        poisonTickTimes.Add(ticks);
        StartCoroutine(Poison());
    }

    IEnumerator Burn()
    {
        while(burnTickTimes.Count > 0)
        {
            for(int i = 0; i < burnTickTimes.Count; i++)
            {
                burnTickTimes[i]--;
            }
            player.currentHealth -= 2;
            burnTickTimes.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }

    IEnumerator Poison()
    {
        while(poisonTickTimes.Count > 0)
        {
            for(int i = 0; i < poisonTickTimes.Count; i++)
            {
                poisonTickTimes[i]--;
            }
            player.currentHealth -= 1;
            poisonTickTimes.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(1.5f);
        }
    }
}

