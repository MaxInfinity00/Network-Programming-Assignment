# Networking Assignment

trying to achieve VG including another networking project I did 

2. **Health Packs:**  [Points: 1]
	Made a HealthPickup class that words on Trigger
    Added a PickupHealth function to the Health Class

4. **Limited Ammo:**  [Points: 1]
	Added an ammo variable to the FiringActionClass, gets checked on both the owning client and the server before firing

5. **Shot Timer:**  [Points: 1]
	Added a canFire bool variable thats gets set to false on shooting and resets to true after a certain amount of time,
    bool gets checked on both the owning client and the server before firing
    
6. **Ammo Packs:**  [Points: 1]
	Made a AmmoPickup class that words on Trigger,
    Added a PickupAmmo function to the Firing Action Class

8. **Shield Power-Up:**  [Points: 2]
	Made a ShieldPickup class that words on Trigger,
    Added a shield variable, PickupShield function to the Health Class,
    made changed to the take damage function to take shield into account
    update the HealthUI class to display shields in UI

9. **Player Death:** [Points: 1]
	Added Despawning behavior in the Health class once the health reaches 0

11. **Limited Respawn:**  [Points: 2]
	Added respawning behavior in the Health class as long as lives are above 0

14. **Burst of Speed Power-Up:** [Points: 1]
	Made a SpeedPickup class that words on Trigger,
    Added a PickupSpeed rpc function and a ResetSpeed function in the Firing Action Class,
    ResetSpeed gets invoked automatically after 5 seconds of boost 

**A link to the side projects Git included in the submission**