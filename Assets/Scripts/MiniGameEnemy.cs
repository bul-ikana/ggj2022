using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameEnemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    private float impulseForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-impulseForce,0.0f),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player) {
            rb.AddForce(new Vector2(2*impulseForce,0.0f),ForceMode2D.Impulse);
            // Application.LoadLevel(Application.loadedLevel);
        }
    }
}
