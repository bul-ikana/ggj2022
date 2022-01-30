using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MiniGameEnemy : MonoBehaviour
{
    public float speedForce = 5.0f;

    private Rigidbody2D rb;
    private int direction = -1;

    private GameManagerScript gameManager;
    private bool moveInit = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            gameManager.ChangeView(gameManager.getCurrentScene());
        }
        else if(collision.tag == "MinigameEnemyReverser"){
            direction = -direction;
            rb.AddForce(new Vector2(2*direction*speedForce,0.0f),ForceMode2D.Impulse);
        }
        else if(Mathf.Abs(rb.velocity.x) < Mathf.Abs(speedForce) && !moveInit){
            moveInit = true;
            rb.AddForce(new Vector2(direction*speedForce,0.0f),ForceMode2D.Impulse);
        }        
    }
}
