using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerTransform;
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 3.0f;

    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("No object with tag 'Player' found in the scene.");
        }
    }

    void Update()
    {
        // Get the direction towards the target
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0; // Prevent rotation on the y-axis

        // Rotate towards the target
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        // Move towards the target
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
