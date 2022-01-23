using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameControls : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5.0f;
    public float jumpForce = 50.0f;

    private Rigidbody2D playerBody;
    private Collider2D playerCollider;
    private float horizontalMovement = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Rigid body and collider from player object
        playerBody = player.GetComponent<Rigidbody2D>();
        playerCollider = player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move factor from -1 to 1 for left to right
        horizontalMovement = Input.GetAxis("Horizontal");

        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int contactCount = playerCollider.GetContacts(contacts);
        float verticalNormalSum = 0.0f;
        for(int i = 0; i < contactCount; i++){
            // Debug.LogError(contacts[i].normal);
            verticalNormalSum += Mathf.Abs(contacts[i].normal.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && verticalNormalSum > 0.0f)
        {
            playerBody.AddForce(new Vector2(0.0f,jumpForce),ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Move Horizontal
        playerBody.velocity = new Vector2(horizontalMovement * moveSpeed, playerBody.velocity.y);
    }
}
