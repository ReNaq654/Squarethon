using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;
    public GameObject player;
    public GameObject wall;
    public GameObject DeathBlock;

    // Start is called before the first frame update
    void Start()
    {
        DeathBlock = GameObject.FindWithTag("DeathBlock");
        wall = GameObject.FindWithTag("Terrain");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        player.SetActive(true);
        wall.SetActive(true);
        DeathBlock.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        player.SetActive(false);
        wall.SetActive(false);
        DeathBlock.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
}
