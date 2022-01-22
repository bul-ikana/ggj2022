using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaCamera : MonoBehaviour
{
    GameObject mecha;
    Vector3 newPosition;

    void Start()
    {
        mecha = GameObject.Find("Mecha");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        newPosition.x = mecha.transform.position.x;
        newPosition.y = mecha.transform.position.y;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}


// void Start ()
// {
//     offset.x = transform.position.x - player.transform.position.x;
//     offset.z = transform.position.z - player.transform.position.z;
//     newtrans=transform.position;
// //not taking y as we won't update y position. 

// }
// void LateUpdate ()
// {
// newtrans.x= player.transform.position.x + offset.x;
// newtrans.z= player.transform.position.z + offset.z;
// transform.position = newtrans;
// }

// }