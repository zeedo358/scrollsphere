using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSphere : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public Material[] materials;

    private void Awake()
    {
        if (PlayerPrefs.GetString("1") != "Open")
        {
            PlayerPrefs.SetString("1", "Open");
            PlayerPrefs.SetString("Now Cube", "1");

        }
    }
    void Start()
    {
        
        this.GetComponent<MeshRenderer>().material = materials[Convert.ToInt32(PlayerPrefs.GetString("Now Cube"))];
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * jumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
