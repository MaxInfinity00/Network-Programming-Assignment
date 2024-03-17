using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class AmmoPickup : NetworkBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(IsServer){
            FiringAction fa = other.GetComponent<FiringAction>();
            if(!fa) return;
            fa.PickupAmmo();
        
            NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
            networkObject.Despawn();
        }
    }
}