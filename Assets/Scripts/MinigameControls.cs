using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameControls : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5;

    private Rigidbody2D playerBody;
    private float horizontalMovement = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Rigid body from player object
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move factor from -1 to 1 for left to right
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Move Horizontal
        playerBody.velocity = new Vector2(horizontalMovement * moveSpeed, playerBody.velocity.y);
    }
}
