using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 2.0f;

    [SerializeField]
    private float damage;

    private void Start()
    {
        Destroy (gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage (damage);

            Destroy (gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }
}
