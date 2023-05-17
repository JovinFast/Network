using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
public class ZombieResetTarget : AttributesSync
{
    ZombieController zombieController;
    private void Start()
    {
        zombieController = GetComponentInParent<ZombieController>();       
    }
    [SynchronizableMethod]
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && zombieController.targetPlayer == other.transform.gameObject)
        {
            zombieController.ResetTarget();
        }
    }
}
