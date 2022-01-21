using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaControls : MonoBehaviour
{
    MechaActions mecha;
    
    // Start is called before the first frame update
    void Start()
    {
        mecha = GameObject.Find("Mecha").GetComponent<MechaActions>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate
        mecha.RotateToCursor();

        // Move Up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            mecha.MoveUp();
        }

        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            mecha.MoveLeft();   
        }

        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            mecha.MoveRight();
        }
        
        // Move Down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            mecha.MoveDown();
        }
    }
}
