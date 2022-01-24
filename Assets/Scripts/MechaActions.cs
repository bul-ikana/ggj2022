using UnityEngine;

public class MechaActions : MonoBehaviour
{
    public int health = 200;
    public float moveSpeed = 5;
    public bool canDisembark = false;

    HealthBarActions hb;
    Transform shootPoint;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hb = GameObject.Find("HealthBar").GetComponent<HealthBarActions>();
        hb.SetMaxHealth(health);
        shootPoint = GameObject.Find("ShootPoint").transform;
    }

    public void Move(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    public void Rotate(float angle)
    {
        rb.MoveRotation(angle);
    }

    public void Shoot()
    {
        Instantiate(Resources.Load("BulletPrefab"), shootPoint.position, shootPoint.rotation);
    }

    public void Damage(int damage) {
        health -= damage;
        hb.SetHealth(health);
        if (health <= 0) {
            Die();
        }
    }

    public void AllowDisembark()
    {
        canDisembark = true;
    }

    public void DenyDisembark()
    {
        canDisembark = false;
    }

    public void Disembark()
    {
        Debug.Log("Change Screen");
    }

    void Die()
    {
        Destroy(this.gameObject);
        Application.LoadLevel(Application.loadedLevel);
    }
}
