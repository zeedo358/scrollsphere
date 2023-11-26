using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause_Menu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pausemenuUi;
    public GameObject controlHeroButtons;
    private int _allowScene;
    private AudioSource _audio;
    private int _coins;
    



    void Update()
    {

        if (gameIsPaused == false)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        void Resume()
        {
            pausemenuUi.SetActive(false);
            Time.timeScale = 1f;
            //AudioListener.pause = false;

            gameIsPaused = false;
            controlHeroButtons.SetActive(true);
        }
        void Pause()
        {
            pausemenuUi.SetActive(true);
            Time.timeScale = 0f;
            //AudioListener.pause = true;

            gameIsPaused = true;
            controlHeroButtons.SetActive(false);
        }
    }
    public void Menu()
    {
        _coins = PlayerPrefs.GetInt("Coins");
        _coins += LoadGame.money;
        PlayerPrefs.SetInt("Coins", _coins);
        SceneManager.LoadScene(0);
        gameIsPaused = false;
        Time.timeScale = 1f;

    }
    public void Resume()
    {
        gameIsPaused = false;
        LoadGame.audio.UnPause();
    }
    

    
}