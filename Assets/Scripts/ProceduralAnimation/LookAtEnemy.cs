using System.Collections.Generic; // Required for using List<T>
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    /*public List<Transform> enemies = new List<Transform>(); // List of enemy transforms

    private void Update()
    {
        if (enemies.Count == 0)
            return; // No enemies in the scene, exit early

        Transform nearestEnemy = GetNearestEnemy();
        if (nearestEnemy != null)
        {
            // Rotate the transform to look at the nearest enemy
            transform.LookAt(nearestEnemy);
        }
    }

    private Transform GetNearestEnemy()
    {
        Transform nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Transform enemy in enemies)
        {
            if (enemy == null)
                continue; // Skip null references

            float distance = Vector3.Distance(transform.position, enemy.position);
            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        return nearestEnemy;
    }

    public void AddEnemy(Transform enemyTransform)
    {
        enemies.Add(enemyTransform);
    }

    public void RemoveEnemy(Transform enemyTransform)
    {
        enemies.Remove(enemyTransform);
    }*/
    [SerializeField]private float rotationSpeed = 1.0f, rotationFactor = 90;

    void Update() 
    {
        FindClosestEnemy();
    }


    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distanceToClosestEnemy)
            {

                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }

            if (closestEnemy != null)
            {
                Vector3 targetDirection = closestEnemy.transform.position - transform.position;
                targetDirection *= rotationFactor;
                targetDirection.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection,Vector3.up);

                Vector3 eulerOffset = new Vector3(0,rotationFactor,0);
                Quaternion offsetRotation = Quaternion.Euler(eulerOffset);
                targetRotation *= offsetRotation;
                transform.rotation = targetRotation;

            }
        }

    }



}