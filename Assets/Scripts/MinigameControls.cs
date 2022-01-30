using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameControls : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 80.0f;
    public string powerObtained = "";

    private Animator animator;
    private GameObject mainCamera;
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
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
        mainCamera = GameObject.FindWithTag("MainCamera");
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
        newCameraPosition.x = Mathf.Max(0.0f,gameObject.transform.position.x);
        newCameraPosition.y = gameObject.transform.position.y;//Mathf.Max(0.0f,gameObject.transform.position.y);
        newCameraPosition.z = mainCamera.transform.position.z;
        mainCamera.transform.position = newCameraPosition;
    }

    void FixedUpdate()
    {
        // Move Horizontal
        velocityHandler.x = horizontalMovement * moveSpeed;
        velocityHandler.y = playerBody.velocity.y;
        playerBody.velocity = velocityHandler;

				if (horizontalMovement < 0) gameObject.GetComponent<SpriteRenderer>().flipX = true;
				else if (horizontalMovement > 0) gameObject.GetComponent<SpriteRenderer>().flipX = false;

				// Animation control
				if (horizontalMovement != 0f) animator.SetBool("isMoving", true);
				else animator.SetBool("isMoving", false);
				if (playerBody.velocity.y != 0f) animator.SetBool("isJumping", true);
				else animator.SetBool("isJumping", false);
    }
}
