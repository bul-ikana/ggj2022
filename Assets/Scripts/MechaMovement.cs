using UnityEngine;

public class MechaMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    public void moveUp()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    public void moveDown()
    {
        transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
    }

    public void moveLeft()
    {
        transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
    }

    public void moveRight()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveUp();
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveLeft();   
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight();
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            moveDown();
        }
    }
}
