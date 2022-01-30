using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameControls : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 80.0f;
    public string powerObtained = "";

    public Rect sceneBounds;

    private Animator animator;
    private GameObject mainCamera;
    private Rigidbody2D playerBody;
    private Collider2D playerCollider;
    private float horizontalMovement = 0.0f;
    private Vector3 newCameraPosition;
    private ContactPoint2D[] contacts = new ContactPoint2D[10];
    private Vector2 velocityHandler;
    private int activePower = 0;
    private GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Rigid body and collider from player object
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
        mainCamera = GameObject.FindWithTag("MainCamera");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            Upgrades upgrades = gameManager.getPlayerUpgrades();

            List<string> powersList = new List<string>();
            powersList.Add("0");
            if (upgrades.hasBombs || upgrades.mgHasBombs) powersList.Add("1");
            if (upgrades.hasLaser || upgrades.mgHasLaser) powersList.Add("2");
            if (upgrades.hasVision || upgrades.mgHasVision) powersList.Add("3");
            if (upgrades.hasEnergy || upgrades.mgHasEnergy) powersList.Add("4");

            // public bool hasBombs = false;
            // public bool hasLaser = false;
            // public bool hasVision = false;
            // public bool hasEnergy = false;

            // public bool mgHasBombs = false;
            // public bool mgHasLaser = false;
            // public bool mgHasVision = false;
            // public bool mgHasEnergy = false;
            
            activePower = (activePower+1)%powersList.Count;
            animator.Play("HumanStand"+powersList[activePower]);
        }        
    }

    void LateUpdate()
    {
        newCameraPosition.x = Mathf.Max(sceneBounds.xMin,Mathf.Min(sceneBounds.xMax,gameObject.transform.position.x));
        newCameraPosition.y = Mathf.Max(sceneBounds.yMax,Mathf.Min(sceneBounds.yMin,gameObject.transform.position.y));
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

    void OnDestroy()
    {
        GameManagerScript gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        gm.toggleMinigameUpgrade(powerObtained);
    }
}
