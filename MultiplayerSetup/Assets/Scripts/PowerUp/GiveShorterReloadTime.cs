using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class GiveShorterReloadTime : AttributesSync
{
    private Alteruna.Avatar avatar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {         
            if (other.TryGetComponent(out Alteruna.Avatar _avatar) && _avatar.IsMe)
            {
                Debug.Log("pickUp");
                other.gameObject.GetComponent<Shoot>().DecreaseReloadSpeed();
            }
            InvokeRemoteMethod(nameof(DestroyPowerUp), UserId.AllInclusive);
        }
    }


    [SynchronizableMethod]
    private void DestroyPowerUp()
    {
        Destroy(gameObject);
    }
}
