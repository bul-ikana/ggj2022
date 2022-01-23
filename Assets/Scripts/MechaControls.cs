using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaControls : MonoBehaviour
{
    MechaActions mecha;
    
    void Start()
    {
        mecha = GameObject.Find("Mecha").GetComponent<MechaActions>();
    }

    void Update()
    {
        // Rotate
        mecha.RotateToCursor();

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            mecha.Shoot();
        }

        // Move Up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            mecha.Move(Vector2.up);
        }

        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            mecha.Move(Vector2.left);
        }

        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            mecha.Move(Vector2.right);
        }
        
        // Move Down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            mecha.Move(Vector2.down);
        }

        // Stop moving
        if (!Input.anyKey) {
            mecha.Stop();
        }
    }
}
