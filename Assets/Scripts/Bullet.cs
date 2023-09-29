using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // Adjust the bullet speed as needed
    private Vector3 targetPosition;
    WavesController wave;

    private void Start()
    {
        wave = GameObject.FindGameObjectWithTag("manager").GetComponent<WavesController>();
        wave.EnimiesKilled = 0;
    }
    // Set the target position for the bullet to move towards
    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
    }

    private void Update()
    {
        // Move the bullet towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the bullet has reached the target position
        if (transform.position == targetPosition)
        {
            // Destroy the bullet when it reaches the target position
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collides with an enemy
        if (collision.gameObject.tag == "enemy")
        {
            wave.EnimiesKilled += 1;
            // Destroy the enemy and the bullet
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
