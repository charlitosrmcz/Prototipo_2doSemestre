using UnityEngine;

public class Enemy : Character
{
    private Player player;

    [SerializeField]
    private AudioClip[] deathSounds;

    [SerializeField]
    private AudioClip playerDamageSound;

    [SerializeField]
    private float startHealth = 5;

    [SerializeField]
    private float damage;

    [SerializeField]
    public GameObject bloodParticlesPrefab;

    private void Start()
    {
        SetEnemyHealth (startHealth);
    }

    void Awake()
    {
        Player playerRef = GameObject.FindObjectOfType<Player>();
        if (playerRef != null)
        {
            player = playerRef;
        }
        else
        {
            Debug
                .LogWarning("No object with type 'Player' found in the scene.");
        }
    }

    public void SetEnemyHealth(float newHealth)
    {
        Health = newHealth;
    }

    public float GetEnemyHealth()
    {
        return Health;
    }

    public void SetPlayerPoints(int newPoints)
    {
        player.SetPlayerPoints (newPoints);
    }

    public override void Die()
    {
        Instantiate(bloodParticlesPrefab,
        transform.position,
        Quaternion.identity);

        int indexAleatorio = Random.Range(0, deathSounds.Length);
        AudioSource
            .PlayClipAtPoint(deathSounds[indexAleatorio], transform.position);

        Destroy (gameObject);
        SetPlayerPoints(player.GetPlayerPoints() + 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage (damage);
            AudioSource.PlayClipAtPoint(playerDamageSound, transform.position);
        }
    }
}
