using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameEnemy : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player) {
            //Application.LoadLevel(Application.loadedLevel);
        }
    }
}
