using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    // bullet variables
    [SerializeField] private InputActionReference shoot;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform BulletParent;
    [SerializeField] private float bulletSpeed = 4.0f;
    [SerializeField] public Transform orient;

    // Enable and disable the shoot action
    void OnEnable() {
        shoot.action.performed += Shoot;
    }

    void OnDisable() {
        shoot.action.performed -= Shoot;
    }

    private void Shoot(InputAction.CallbackContext obj) // Shoot function to instantiate a bullet and give it velocity
    {
        // Create a new bullet
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        // Set the bullet's parent to the BulletParent
        bullet.transform.SetParent(BulletParent);
        //Position the bullet in desired orientation
        bullet.transform.position = orient.position;
        // Give it velocity in the direction of the orientation, no up or down
        bullet.GetComponent<Rigidbody>().velocity = orient.forward * bulletSpeed;

        // Shoot sfx
        FindObjectOfType<AudioManager>().PlayPlayerAttack1();

        // wait for 2 second before destroying the bullet
        Destroy(bullet.gameObject, 1);
    }
}
