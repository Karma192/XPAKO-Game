using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private GameObject Spawn;
    private GameObject Boss;
    private GameObject Weapons;
    private GameObject Bullets;

    void Start()
    {
        Spawn = GameObject.Find("SpawnEnemy1");
        Boss = GameObject.Find("SpawnBoss");
        Weapons = GameObject.Find("WeaponsFolder");
        Bullets = GameObject.Find("BulletsFolder");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        Spawn.SetActive(true);
        Boss.SetActive(true);
        Weapons.SetActive(true);
        Bullets.SetActive(true);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Spawn.SetActive(false);
        Boss.SetActive(false);
        Weapons.SetActive(false);
        Bullets.SetActive(false);
    }
}
