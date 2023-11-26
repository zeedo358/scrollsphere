using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class ControlHero : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    public GameObject player;
    
    public VariableJoystick mContr;
    Vector3 position;
    public Material[] materials;


    public static bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<MeshRenderer>().material = materials[Convert.ToInt32(PlayerPrefs.GetString("Now Cube"))];
        rb = GetComponent<Rigidbody>();
        position = transform.position;
        position = new Vector3(UnityEngine.Random.Range(-76.3f, 83.7f), 13.75f, UnityEngine.Random.Range(-51.2f, 18.8f));
        this.gameObject.transform.position = position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = mContr.Horizontal;
        float moveVertical = mContr.Vertical;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);


        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            isDeath = true;
            
        }
    }

    
}
