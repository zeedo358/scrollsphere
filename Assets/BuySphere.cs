using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BuySphere : MonoBehaviour
{
    public GameObject whichCube, selectBtn;
    public Text coins;
    private int _money;
    public int[] costofSkins;

    
    public void Buy()
    {
        if(PlayerPrefs.GetInt("Coins") >= costofSkins[Convert.ToInt32(PlayerPrefs.GetString("Now Cube"))]) // Buy cube
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - costofSkins[Convert.ToInt32(PlayerPrefs.GetString("Now Cube"))]);
            _money = PlayerPrefs.GetInt("Coins");
            coins.text = "Coins: " + _money;
            PlayerPrefs.SetString(whichCube.GetComponent<SelectSkin>().nowCube,"Open");
            selectBtn.SetActive(true);
            gameObject.SetActive(false);
            
            
        }
    }
    public void Select()
    {
        PlayerPrefs.SetString("Now Cube", whichCube.GetComponent<SelectSkin>().nowCube);
        


    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
