using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIforgameower : MonoBehaviour
{
    public Text text;
    int coins;
    public Button DoubleCoins;

    
    void Start()
    {
        coins = LoadGame.money;
        if (coins == 0)
        {
            DoubleCoins.gameObject.SetActive(false);
        }
        text.text = "All money which you have: " + coins;
        int monets = PlayerPrefs.GetInt("Coins");
        monets += coins;
        PlayerPrefs.SetInt("Coins", monets);
    }

    
    
    public void menu()
    {
        
        SceneManager.LoadScene(0);
        GameOwerMenu.GameIsOwer = false;
        ControlHero.isDeath = false;
        DoubleCoins.gameObject.SetActive(true);
    }

   
    public void DoubleeCoins()
    {
        
        DoubleCoins.gameObject.SetActive(false);
        text.text = "All money which you have: " + coins*2;
        int monets = PlayerPrefs.GetInt("Coins");
        monets += coins;
        PlayerPrefs.SetInt("Coins", monets);

    }
}
