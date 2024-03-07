using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    [SerializeField] private InputActionReference shoot;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform BulletParent;
    [SerializeField] private float bulletSpeed = 2.0f;
    [SerializeField] public Transform orient;

    private Coroutine shootingCoroutine;

    void OnEnable() {
        shoot.action.performed += Shoot;
    }

    void OnDisable() {
        shoot.action.performed -= Shoot;
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        Debug.Log("Shoot method called");
        shootingCoroutine = StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        Debug.Log("ShootCoroutine started");
        while (true)
        {
            // Create a new bullet
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // Set the bullet's parent to the BulletParent
            bullet.transform.SetParent(BulletParent);
            //Position the bullet in desired orientation
            bullet.transform.position = orient.position;
            // Give it velocity
            bullet.GetComponent<Rigidbody>().velocity = orient.forward * bulletSpeed;

            // Sleep for a while
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
{
    if(Input.GetKeyUp(KeyCode.E))
    {
        // Check if the coroutine is not null before trying to stop it
        if (shootingCoroutine != null)
        {
            // Stop the coroutine
            StopCoroutine(shootingCoroutine);
            // Set shootingCoroutine to null
            shootingCoroutine = null;
        }
    }
}
}
