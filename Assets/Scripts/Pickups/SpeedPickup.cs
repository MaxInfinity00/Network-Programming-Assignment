using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SpeedPickup : NetworkBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(IsServer){
            PlayerController controller = other.GetComponent<PlayerController>();
            if(!controller) return;
            controller.PickupSpeedClientRpc();
        
            NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
            networkObject.Despawn();
        }
    }
}