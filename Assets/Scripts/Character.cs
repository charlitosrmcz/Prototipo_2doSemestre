using UnityEngine;

public class Character : MonoBehaviour
{
    private int points;

    private float health;

    private float maxHealth;

    public int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
    }

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("Die");
    }

    public virtual void Attack()
    {
        Debug.Log("Attack");
    }

    public void Healing(float heal)
    {
        if ((health + heal) > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += heal;
        }
    }
}
