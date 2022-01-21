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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            mecha.moveUp();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            mecha.moveLeft();   
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            mecha.moveRight();
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            mecha.moveDown();
        }   
    }
}
