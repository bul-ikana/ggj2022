using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameControls : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 10.0f;
    public float jumpForce = 80.0f;

    private Rigidbody2D playerBody;
    private Collider2D playerCollider;
    private float horizontalMovement = 0.0f;
    private Vector3 newCameraPosition;
    private ContactPoint2D[] contacts = new ContactPoint2D[10];
    private Vector2 velocityHandler;

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
        
        // Jump is enabled only when is touching floor
        int contactCount = playerCollider.GetContacts(contacts);
        float verticalNormalSum = 0.0f;
        for(int i = 0; i < contactCount; i++)
        {
            verticalNormalSum += Mathf.Abs(contacts[i].normal.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && verticalNormalSum > 0.0f)
        {
            playerBody.AddForce(new Vector2(0.0f,jumpForce),ForceMode2D.Impulse);
        }        
    }

    void LateUpdate()
    {
        newCameraPosition.x = Mathf.Max(0.0f,player.transform.position.x);
        newCameraPosition.y = Mathf.Max(0.0f,player.transform.position.y);
        newCameraPosition.z = transform.position.z;
        transform.position = newCameraPosition;
    }

    void FixedUpdate()
    {
        // Move Horizontal
        velocityHandler.x = horizontalMovement * moveSpeed;
        velocityHandler.y = playerBody.velocity.y;
        playerBody.velocity = velocityHandler;
    }
}
