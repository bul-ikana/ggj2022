using UnityEngine;

public class MechaActions : MonoBehaviour
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
}
