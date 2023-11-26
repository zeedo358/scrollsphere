using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOwerMenu : MonoBehaviour
{
    public static bool GameIsOwer = false;
    public GameObject gameowerUI;
    public GameObject ControlHeroButtons;
    public GameObject PauseMenu;
    int AllowScene;

    

    void Update()
    {

        if (GameIsOwer == false)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        void Resume()
        {
            gameowerUI.SetActive(false);
            PauseMenu.SetActive(true);
            Time.timeScale = 1f;
            AudioListener.pause = false;
            GameIsOwer = false;
            ControlHeroButtons.SetActive(true);
        }
        void Pause()
        {
            gameowerUI.SetActive(true);
            PauseMenu.SetActive(false);
            Time.timeScale = 0f;
            AudioListener.pause = true;
            ControlHeroButtons.SetActive(false);
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        GameIsOwer = false;
        Time.timeScale = 1f;

    }
    public void Resume()
    {
        GameIsOwer = false;
    }

}