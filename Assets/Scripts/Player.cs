using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private float fireRate = 0.2f;

    private float nextFireTime = 0f;

    private float lastAttackTime;

    public float rotationSpeed = 5f;

    public Transform triggerPosition;

    [SerializeField]
    private float

            startHealth = 10,
            startMaxHealth = 10;

    [SerializeField]
    private AudioClip attackSound;

    [SerializeField]
    private AudioClip dieSound;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Attack();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        SetPlayerHealth (startHealth);
        SetMaxPlayerHealth (startMaxHealth);
    }

    public void SetPlayerHealth(float newHealth)
    {
        Health = newHealth;
    }

    public float GetPlayerHealth()
    {
        return Health;
    }

    public void SetPlayerPoints(int newPoints)
    {
        Points = newPoints;
    }

    public void SetMaxPlayerHealth(float newMaxHealth)
    {
        MaxHealth = newMaxHealth;
    }

    public float GetMaxPlayerHealth()
    {
        return MaxHealth;
    }

    public int GetPlayerPoints()
    {
        return Points;
    }

    public override void Die()
    {
        AudioSource.PlayClipAtPoint(dieSound, transform.position);
    }

    public override void Attack()
    {
        AudioSource.PlayClipAtPoint(attackSound, transform.position);
        Quaternion targetDirection = triggerPosition.rotation;
        Vector3 eulerOffset = new Vector3(0, -90, 0);
        Quaternion offsetRotation = Quaternion.Euler(eulerOffset);

        GameObject bullet =
            Instantiate(projectilePrefab,
            transform.position,
            targetDirection * offsetRotation);
    }
}
