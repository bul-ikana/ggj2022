using UnityEngine;

public class MechaActions : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float moveSpeed;

    public int maxWeapon;
    public int currentWeapon;

    MechaUI ui;
    Rigidbody2D rb;
    Transform shootPoint;
    GameManagerScript gameManager;

    void Start()
    {
        ui = GetComponent<MechaUI>();
        rb = GetComponent<Rigidbody2D>();
        shootPoint = GameObject.Find("ShootPoint").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        ui.InitializeHealth(health, maxHealth);
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
        Instantiate(Resources.Load("Bullet" + (currentWeapon + 1) + "Prefab"), shootPoint.position, shootPoint.rotation);
    }

    public void ChangeWeapon()
    {
        currentWeapon = (currentWeapon + 1) % maxWeapon;

        ui.UpdateWeapon(currentWeapon);
    }

    public void Damage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }

        ui.UpdateHealth(health);
    }

    public void Heal(int amount)
    {
        health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        ui.UpdateHealth(health);
    }

    void Die()
    {
      	gameManager.ChangeView("Gameover");
        Destroy(this.gameObject);
    }
}
