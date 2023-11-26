using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandColor : MonoBehaviour
{
    public Material[] blocks;
    public int index = 0;
    public static int randomBlockForDelete;

    private float _timer;
    private void Awake()
    {
        randomBlockForDelete = Random.Range(0, blocks.Length);
        _timer = LoadGame.timer;
    }

    void Start()
    {
        
        RandomColor();
        ChangeColor();
        Invoke("DestroyBlocks", _timer);
        
    }

    void DestroyBlocks()
    {
        
        if (index != randomBlockForDelete)
        {
            this.gameObject.SetActive(false);
        }
    }


    void RandomColor()
    {
        index = Random.Range(0, blocks.Length);
    }
    void ChangeColor()
    {
        MeshRenderer g = this.GetComponent("MeshRenderer") as MeshRenderer;
        if (index < blocks.Length)
        {
            
            g.material = blocks[index];
        }
    }
}
