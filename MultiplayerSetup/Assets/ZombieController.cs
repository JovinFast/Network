using UnityEngine;
using Alteruna;
public class ZombieController : AttributesSync
{
    //public float movementSpeed = 3f; // Speed at which the zombie moves towards the player
    //public float detectionRange = 10f; // Range at which the zombie detects the player
    public float moveForce = 500f; // Force applied to move the zombie

    public GameObject targetPlayer; // Reference to the closest player's transform
    private bool isPlayerInRange = false; // Flag to track if a player is in range
    private bool isPursuing = false; // Flag to track if the zombie is actively pursuing a target
    private RigidbodySynchronizable zombieRigidbody; // Reference to the zombie's rigidbody
    AudioSource aS;
    private Alteruna.Avatar avatar;
    [SerializeField]ZombieDealDamage ZombieDamageScript;

    private void Awake()
    {
        zombieRigidbody = GetComponent<RigidbodySynchronizable>();
        aS = GetComponent<AudioSource>();
    }
 

    private void FixedUpdate()
    {
        if (isPursuing && targetPlayer != null)
        {
            //MoveTowardsPlayer();
            InvokeRemoteMethod(nameof(MoveTowardsPlayer), UserId.AllInclusive);
        }
    }
   [SynchronizableMethod]
    private void MoveTowardsPlayer()
    {

        
        if (!ZombieDamageScript.canDealDamage)
        {
            zombieRigidbody.velocity = Vector3.zero;
            return;
        }
        
            // Calculate the direction towards the player
            Vector3 direction = targetPlayer.transform.position - transform.position;
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
            avatar = other.GetComponent<Alteruna.Avatar>();
            isPlayerInRange = true;

            // Check if the new player is closer than the current target
            GameObject playerTransform = other.gameObject;
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.transform.position);

            if (targetPlayer == null || distanceToPlayer < Vector3.Distance(transform.position, targetPlayer.transform.position))
            {
                if (avatar.IsMe) aS.Play();
                //targetPlayer = playerTransform;
                SetPlayerTarget(playerTransform);
                isPursuing = true; // Start pursuing the target
            }
        }
    }



    public void ResetTarget()
    {
        isPlayerInRange = false;
        isPursuing = false; // Stop pursuing the target
        targetPlayer = null; // Reset the target player reference
        avatar = null;
    }
    //[SynchronizableMethod]
    private void SetPlayerTarget(GameObject other)
    {
        targetPlayer = other;
    }
}
