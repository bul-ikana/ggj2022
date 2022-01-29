using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedEnemyActions : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }
}
