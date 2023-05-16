using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieResetTarget : MonoBehaviour
{
    ZombieController zombieController;
    private void Start()
    {
        zombieController = GetComponentInParent<ZombieController>();       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && zombieController.targetPlayer == other.transform.gameObject)
        {
            zombieController.ResetTarget();
        }
    }
}
