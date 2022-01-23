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

    void Update()
    {
        newPosition.x = mecha.transform.position.x;
        newPosition.y = mecha.transform.position.y;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
