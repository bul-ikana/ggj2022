using UnityEngine;

public class MechaActions : MonoBehaviour
{
    public int health = 200;

    Transform shootPoint;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootPoint = GameObject.Find("ShootPoint").transform;
    }

    public float moveSpeed = 5;

    public void Move(Vector2 direction)
    {
        Vector2 move = rb.velocity + direction;
        rb.velocity = move.normalized * moveSpeed;
    }

    public void MoveUp()
    {
        rb.velocity = Vector2.up * moveSpeed;
    }

    public void MoveDown()
    {
        rb.velocity = Vector2.up * -moveSpeed;
    }

    public void MoveLeft()
    {
        rb.velocity = Vector2.right * -moveSpeed;
    }

    public void MoveRight()
    {
        rb.velocity = Vector2.right * moveSpeed;
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
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

    public void Damage(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        Application.LoadLevel(Application.loadedLevel);
    }
}
