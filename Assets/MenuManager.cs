using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text text;
    private int _coins;
    
    
    
    void Start()
    {
        _coins = PlayerPrefs.GetInt("Coins");
        text.text = "Coins: " + _coins;

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        
    }
    public void Settings()
    {
        SceneManager.LoadScene(2);
        
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    
      
    
    public void Shop()
    {
        SceneManager.LoadScene(3);
    }
}
