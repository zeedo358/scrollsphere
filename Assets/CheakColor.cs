using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheakColor : MonoBehaviour
{
    public Material[] blocks;
    public Image img;
    


    public void Start()
    {
        

    }

    
    void Update()
    {
        int RandomBlockForDel = RandColor.randomBlockForDelete;
        img.color = blocks[RandomBlockForDel].color;

    }
}
