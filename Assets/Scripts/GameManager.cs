using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int level;
    public int lives;
    public int score;
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    public void NewGame()
    {
        lives = 3;
        score = 0;
        LoadLevel(1);
    }
    public void LoadLevel(int index)
    {
        level = index;

        Camera cam = Camera.main;
        if (cam != null)
        {
            cam.cullingMask = 0;
        }
        Invoke(nameof(LoadScene), 1);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void LevelComplete()
    {
        score += 1000;
        int nextLevel = level + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }
        else
        {
            LoadLevel(1);
        }
    }

    public void LevelFailed()
    {
        lives--;
        if (lives <= 0)
        {
            NewGame();
        }
        else
        {
            LoadLevel(level);
        }
    }
}