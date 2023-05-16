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
            avatar = other.gameObject.GetComponent<Alteruna.Avatar>();
            if (avatar.IsMe)
            {
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
