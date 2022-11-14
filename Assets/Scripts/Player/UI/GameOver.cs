using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void gameover()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
