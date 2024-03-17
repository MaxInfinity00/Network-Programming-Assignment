using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FiringAction : NetworkBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject clientSingleBulletPrefab;
    [SerializeField] GameObject serverSingleBulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    
    [SerializeField] NetworkVariable<int> ammo = new NetworkVariable<int>(10);
    


    public override void OnNetworkSpawn()
    {
        playerController.onFireEvent += Fire;
    }

    private void Fire(bool isShooting)
    {

        if (isShooting)
        {
            ShootLocalBullet();
        }
    }

    [ServerRpc]
    private void ShootBulletServerRpc()
    {
        if (ammo.Value <= 0) return;
        GameObject bullet = Instantiate(serverSingleBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());
        ammo.Value--; 
        ShootBulletClientRpc();
    }

    [ClientRpc]
    private void ShootBulletClientRpc()
    {
        if (IsOwner) return;
        GameObject bullet = Instantiate(clientSingleBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());

    }

    private void ShootLocalBullet()
    {
        if (ammo.Value <= 0) return;
        
        GameObject bullet = Instantiate(clientSingleBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());

        ShootBulletServerRpc();
    }
    
    public void PickupAmmo()
    {
        ammo.Value = 10;
    }
}
