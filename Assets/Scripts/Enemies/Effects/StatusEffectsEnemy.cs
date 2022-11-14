using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectsEnemy : MonoBehaviour
{
    public GameObject burnFX;
    public GameObject poisonFX;

    private GameObject gmInst;
    private EnemyLifeSys ELS;
    private List<int> burnTickTimes = new List<int>();
    private List<int> poisonTickTimes = new List<int>();
    private List<int> freezeTickTimes = new List<int>();
    private List<int> GMSpellTickTimes = new List<int>();
    private List<int> ThunderTickTimes = new List<int>();

    void Start() 
    {
        ELS = gameObject.GetComponent<EnemyLifeSys>();
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

    public void ApplyFreeze(int ticks)
    {
        freezeTickTimes.Add(ticks);
        StartCoroutine(Freeze());
    }

    public void ApplyGMSpell (int ticks, GameObject effect, GameObject FMob)
    {
        GMSpellTickTimes.Add(ticks);
        if (ELS.GMS == false)
        {
            StartCoroutine(GMSpell(effect, FMob));
        }
    }

    public void ApplyThunder (Transform mob, GameObject spark)
    {
        Thunder(mob, spark);
    }

    private IEnumerator Burn()
    {
        GameObject burn = Instantiate(burnFX, gameObject.transform.position, transform.rotation);
        burn.transform.SetParent(gameObject.transform);
        while(burnTickTimes.Count > 0)
        {
            for(int i = 0; i < burnTickTimes.Count; i++)
            {
                burnTickTimes[i]--;
            }
            ELS.damageTaken += 2;
            burnTickTimes.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
        Destroy(burn);
    }

    private IEnumerator Poison()
    {
        GameObject poison = Instantiate(poisonFX, gameObject.transform.position, transform.rotation);
        poison.transform.SetParent(gameObject.transform);
        while(poisonTickTimes.Count > 0)
        {
            for(int i = 0; i < poisonTickTimes.Count; i++)
            {
                poisonTickTimes[i]--;
            }
            ELS.damageTaken += 1;
            poisonTickTimes.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(1.5f);
        }
        Destroy(poison);
    }

    private IEnumerator Freeze ()
    {
        while(freezeTickTimes.Count > 0)
        {
            for(int i = 0; i < freezeTickTimes.Count; i++)
            {
                freezeTickTimes[i]--;
            }
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            freezeTickTimes.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(1f);
        }
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    private IEnumerator GMSpell (GameObject effect, GameObject FMob)
    {
        GameObject Touch = Instantiate(effect, gameObject.transform.position, transform.rotation);
        Touch.transform.SetParent(gameObject.transform);
        while(GMSpellTickTimes.Count > 0)
        {
            for(int i = 0; i < GMSpellTickTimes.Count; i++)
            {
                GMSpellTickTimes[i]--;
            }
            ELS.GMS = true;
            gmInst = FMob;
            GMSpellTickTimes.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(1f);
        }
        
        ELS.GMS = false;
        Destroy(gmInst);
    }

    private void Thunder (Transform mob, GameObject spark)
    {
        GameObject sparky = Instantiate(spark, mob.position, mob.rotation);
    }

    void OnDestroy ()
    {
        if (ELS.GMS == true)
        {
            GameObject friend = Instantiate(gmInst, gameObject.transform.position, transform.rotation);
            friend.transform.SetParent(GameObject.Find("BulletsFolder").transform);
        }
    }
}
