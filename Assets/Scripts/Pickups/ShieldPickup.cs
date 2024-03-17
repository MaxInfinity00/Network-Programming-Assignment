using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ShieldPickup : NetworkBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(IsServer){
            Health health = other.GetComponent<Health>();
            if(!health) return;
            health.PickupShield();
        
            NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
            networkObject.Despawn();
        }
    }
}