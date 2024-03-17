using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class Health : NetworkBehaviour
{
    public NetworkVariable<int> currentHealth = new NetworkVariable<int>();
    
    public NetworkVariable<int> shield = new NetworkVariable<int>(0);
    
    public NetworkVariable<int> lives = new NetworkVariable<int>(3);
    
    public NetworkTransform networkTransform;


    public override void OnNetworkSpawn()
    {
        if(!IsServer) return;
        currentHealth.Value = 100;
        shield.Value = 2;
        lives.Value = 3;
        networkTransform = GetComponent<NetworkTransform>();
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
        if (IsServer)
        {
            lives.Value--;
            if (lives.Value <= 0)
            {
                NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
                networkObject.Despawn();
            }
            else
            {
                currentHealth.Value = 100;
                RelocateClientRpc();
            }
        }
    }

    [ClientRpc]
    public void RelocateClientRpc()
    {
        if(!IsOwner) return;
        transform.position = new Vector2(Random.Range(-4, 4),Random.Range(-2, 2));
    }
}
