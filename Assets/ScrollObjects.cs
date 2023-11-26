using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour
{
    public GameObject cubes;
    private Vector3 _screenpoint, _offset;
    private float _lockedPos;

    void Start()
    {
        
    }

    void Update()
    {
        if(cubes.transform.position.x > 181.9616)
        {
            cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(181.9616f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 75f);
        }
        else if (cubes.transform.position.x < -349.9616)
        {
            cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(-349.9616f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 75f);
        }
    }
    void OnMouseDown()
    {
        _lockedPos = _screenpoint.x;
        _offset = cubes.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 209.5561f));
        Cursor.visible = false;
    }
    void OnMouseDrag()
    {
        
        Vector3 currentScrenpoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 209.5561f);
        
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScrenpoint) + _offset;
        currentPosition.y = 158.214f;
        currentPosition.z = 209.5561f;
        cubes.transform.position = currentPosition;
        
    }
    void OnMouseUp()
    {
        Cursor.visible = true;
    }
}
