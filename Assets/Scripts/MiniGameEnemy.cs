using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MiniGameEnemy : MonoBehaviour
{
    public float impulseForce = 5.0f;

    private Rigidbody2D rb;
    private int direction = -1;

    private GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(direction*impulseForce,0.0f),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //  Only for debugging
        if (collision.tag == "Player") 
        {
            gameManager.ChangeView(gameManager.getCurrentScene());
        }
        else{
			if(collision.tag == "MinigameEnemyReverser"){
                direction = -direction;
                rb.AddForce(new Vector2(2*direction*impulseForce,0.0f),ForceMode2D.Impulse);
            }
        }
    }
}
