using UnityEngine;

public class MechaActions : MonoBehaviour
{
    Transform shootPoint;

    void Start()
    {
        shootPoint = GameObject.Find("ShootPoint").transform;
    }

    public float moveSpeed = 5;

    public void MoveUp()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    public void MoveDown()
    {
        transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
    }

    public void MoveLeft()
    {
        transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    public void RotateToCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void Shoot()
    {
        Instantiate(Resources.Load("BulletPrefab"), shootPoint.position, shootPoint.rotation);
    }
}
