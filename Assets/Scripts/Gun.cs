using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject objectToFollow;
    public float rotationSpeed = 5f;

    private void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Get the direction from this object to the mouse position
        Vector3 direction = mousePosition - transform.position;
        // Calculate the rotation needed to look in this direction
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
        // Apply the rotation smoothly
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Move this object to the position of the object to follow
        transform.position = objectToFollow.transform.position;
    }

}
