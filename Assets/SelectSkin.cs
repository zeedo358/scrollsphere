using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkin : MonoBehaviour
{
    public GameObject selectCube, buyCube;
    public string nowCube;
    public Text textSLCTBTN;
    public Text coins;
    private int _money;
    public Text costskin;
    public int[] costofSkins;

    private void Start()
    {
        _money = PlayerPrefs.GetInt("Coins");
        coins.text = "Coins: " + _money;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        nowCube = other.gameObject.name;
        other.transform.localScale += new Vector3(10f, 10f, 10f);
        if (PlayerPrefs.GetString(other.gameObject.name) == "Open")
        {
            selectCube.SetActive(true);
            buyCube.SetActive(false);
        }
        else
        {
            selectCube.SetActive(false);
            buyCube.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.localScale -= new Vector3(10f, 10f, 10f);
    }
    private void Update()
    {
        costskin.text = "Cost: " + costofSkins[Convert.ToInt32(nowCube)];
        if (PlayerPrefs.GetString("Now Cube") == nowCube)
        {
            textSLCTBTN.text = "Selected";
            
        }
        else
        {
            textSLCTBTN.text = "Select";
        }

    }
}
