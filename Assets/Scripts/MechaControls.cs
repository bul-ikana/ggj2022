using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaControls : MonoBehaviour
{
    MechaActions mecha;
    Vector2 direction;
    
    void Start()
    {
        mecha = GameObject.Find("Mecha").GetComponent<MechaActions>();
    }

    void LateUpdate()
    {
        RotateMechaToCursor();
        ListenForMechaShoots();
        MoveMecha();
    }

    void MoveMecha()
    {
        direction = Vector2.zero;

        // Move Up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }

        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }

        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }
        
        // Move Down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }

        mecha.Move(direction);
    }

    void RotateMechaToCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(mecha.transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        mecha.Rotate(angle);
    }

    void ListenForMechaShoots()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mecha.Shoot();
        }
    }
}
