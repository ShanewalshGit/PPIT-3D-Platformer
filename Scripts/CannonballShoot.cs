using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannonball : MonoBehaviour
{
    // Cannonball shooting
    [SerializeField] private InputActionReference shootCannonball;
    [SerializeField] private Bullet cannonballPrefab;
    [SerializeField] private Transform BulletParent;
    [SerializeField] private float bulletSpeed = 2.0f;
    [SerializeField] public Transform orient;

    [SerializeField] private float shootCooldown = 5.0f; // Cooldown duration in seconds
    private float lastShootTime; // Time when the last shot was fired

    // Enable and disable the input action
    void OnEnable() { 
        shootCannonball.action.performed += ShootCannonball;
    }

    void OnDisable() {
        shootCannonball.action.performed -= ShootCannonball;
    }

    // shoot cannonball when the input action is performed
    private void ShootCannonball(InputAction.CallbackContext obj)
    {
        if (Time.time - lastShootTime >= shootCooldown)
        {
            // Create a new bullet
            Bullet bullet = Instantiate(cannonballPrefab, transform.position, Quaternion.identity);
            // Set the bullet's parent to the BulletParent
            bullet.transform.SetParent(BulletParent);
            //Position the bullet in desired orientation
            bullet.transform.position = orient.position;
            // Give it velocity
            bullet.GetComponent<Rigidbody>().velocity = orient.forward * bulletSpeed;

            // Shoot sfx
            FindObjectOfType<AudioManager>().PlayPlayerAttack2();

            // wait for 2 second before destroying the bullet
            Destroy(bullet.gameObject, 2);

            // Update the time of the last shot
            lastShootTime = Time.time;

            //FindAnyObjectByType<CooldownIndicator>().UpdateCooldownIcons(shootCooldown, lastShootTime);
        }
        else {
            Debug.Log("Cannonball is on cooldown" + (shootCooldown - (Time.time - lastShootTime)) + " seconds left");
        }
    
    }

    public float GetCooldown()
    {
        return shootCooldown;
    }

    public float GetLastShootTime()
    {
        return lastShootTime;
    }
}
