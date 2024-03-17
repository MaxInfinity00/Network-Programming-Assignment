using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
    public NetworkVariable<int> currentHealth = new NetworkVariable<int>();
    
    public NetworkVariable<int> shield = new NetworkVariable<int>(0);


    public override void OnNetworkSpawn()
    {
        if(!IsServer) return;
        currentHealth.Value = 100;
    }


    public void TakeDamage(int damage){
        if(shield.Value > 0){
            shield.Value--;
            return;
        }
        damage = damage<0? damage:-damage;
        currentHealth.Value += damage;
        if(currentHealth.Value <= 0){
            Die();
        }
    }

    public void PickupShield()
    {
        shield.Value = 2;
    }
    
    public void PickupHealth()
    {
        currentHealth.Value = 100;
    }
    
    public void Die(){
        if(IsServer){
            NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
            networkObject.Despawn();
        }
    }
    

}
