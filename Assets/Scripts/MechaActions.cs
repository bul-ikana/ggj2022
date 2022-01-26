using UnityEngine;

public class MechaActions : MonoBehaviour
{
    public int health = 200;
    public int maxHealth = 200;
    public float moveSpeed = 5;
    public bool canDisembark = false;

    private int gateToDisembark = 0;
    private GameManagerScript gameManager;
    HealthBarActions hb;
    Transform shootPoint;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootPoint = GameObject.Find("ShootPoint").transform;
        hb = GameObject.Find("HealthBar").GetComponent<HealthBarActions>();
    	gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        hb.SetMaxHealth(maxHealth);
        hb.SetHealth(health);

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

    public void Damage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }

        hb.SetHealth(health);
    }

    public void Heal(int amount)
    {
        health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        hb.SetHealth(health);
    }

    public void AllowDisembark(int gateNumber)
    {
      gateToDisembark = gateNumber;
      canDisembark = true;
    }

    public void DenyDisembark()
    {
        gateToDisembark = 0;
        canDisembark = false;
    }

    public void Disembark()
    {
        if (gateToDisembark == 0)
        {
            return;
        }

        gameManager.ChangeView("Gate" + gateToDisembark);
    }

    void Die()
    {
      	gameManager.ChangeView("Gameover");
        Destroy(this.gameObject);
    }
}
