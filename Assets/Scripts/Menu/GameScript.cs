using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void TimeReset ()
    {
        Time.timeScale = 1f;
    }

    public void GameReset ()
    {
        Destroy(GameObject.Find("CharacterManager"));
    }
}