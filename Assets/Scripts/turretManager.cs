using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class turretManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float shootingInterval = 1f;
    public float turretRange = 5f;

    private SpriteRenderer spriteRenderer;
    private float shootingTimer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shootingTimer = shootingInterval;
    }

    private void Update()
    {
        shootingTimer -= Time.deltaTime;

        if (shootingTimer <= 0f)
        {
            ShootBullet();
            shootingTimer = shootingInterval;
        }

        GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            Vector2 turretPosition = transform.position;
            Vector2 enemyPosition = closestEnemy.transform.position;

            // Flip the turret sprite based on the closest enemy's position
            if (enemyPosition.x > turretPosition.x)
                spriteRenderer.flipX = true; // Flip to the right
            else
                spriteRenderer.flipX = false; // Flip to the left
        }
    }

    private void ShootBullet()
    {
       GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, closestEnemy.transform.position);
            if (distanceToEnemy <= turretRange)
            {
                GameObject bulletObject = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                turettBulletManager bullet = bulletObject.GetComponent<turettBulletManager>();
                bullet.SetTarget(closestEnemy.transform);
            }
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;
        Vector2 turretPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(turretPosition, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
