using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannonball : MonoBehaviour
{

    [SerializeField] private InputActionReference shootCannonball;
    [SerializeField] private Bullet cannonballPrefab;
    [SerializeField] private Transform BulletParent;
    [SerializeField] private float bulletSpeed = 2.0f;
    [SerializeField] public Transform orient;

    void OnEnable() {
        shootCannonball.action.performed += ShootCannonball;
    }

    void OnDisable() {
        shootCannonball.action.performed -= ShootCannonball;
    }

    private void ShootCannonball(InputAction.CallbackContext obj)
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
    }
}
