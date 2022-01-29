using UnityEngine;

public class MechaActions : MonoBehaviour
{
    int health;
    int maxHealth;
    public float moveSpeed;

    public int maxWeapon;
    public int currentWeapon;

    private MechaUI ui;
    private Rigidbody2D rb;
    private Transform shootPoint;
    private SoundManager audio;

    void Start()
    {
        ui = GetComponent<MechaUI>();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<SoundManager>();
        shootPoint = GameObject.Find("ShootPoint").transform;

        ui.InitializeHealth();
    }

    public void SetHealth(int setHealth, int setMaxHealth)
    {
        health = setHealth;
        maxHealth = setMaxHealth;
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

        ui.ShakeCamera(damage * 0.1f, 0.2f);
        audio.Play("damage");
        ui.UpdateHealth(health);
    }

    public void Heal(int amount)
    {
        health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        audio.Play("heal");
        ui.UpdateHealth(health);
    }

    void Die()
    {
        ui.GameOver();
        Destroy(this.gameObject);
    }
}
