using UnityEngine;
using Alteruna;
public class ZombieController : MonoBehaviour
{
    public float movementSpeed = 3f; // Speed at which the zombie moves towards the player
    public float detectionRange = 10f; // Range at which the zombie detects the player
    public float moveForce = 500f; // Force applied to move the zombie

    private Transform targetPlayer; // Reference to the closest player's transform
    private bool isPlayerInRange = false; // Flag to track if a player is in range
    private bool isPursuing = false; // Flag to track if the zombie is actively pursuing a target
    private RigidbodySynchronizable zombieRigidbody; // Reference to the zombie's rigidbody
    
    private void Awake()
    {
        zombieRigidbody = GetComponent<RigidbodySynchronizable>();
    }

    private void Update()
    {
        if (isPursuing && targetPlayer != null)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calculate the direction towards the player
        Vector3 direction = targetPlayer.position - transform.position;
        direction.y = 0; // Ignore vertical movement

        // Normalize the direction vector
        direction.Normalize();

        // Apply force to move the zombie
        zombieRigidbody.AddForce(direction * moveForce * Time.deltaTime);

        // Rotate the zombie to face the player
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;

            // Check if the new player is closer than the current target
            Transform playerTransform = other.transform;
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (targetPlayer == null || distanceToPlayer < Vector3.Distance(transform.position, targetPlayer.position))
            {
                targetPlayer = playerTransform;
                isPursuing = true; // Start pursuing the target
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && targetPlayer == other.transform)
        {
            isPlayerInRange = false;
            isPursuing = false; // Stop pursuing the target
            targetPlayer = null; // Reset the target player reference
        }
    }
}
