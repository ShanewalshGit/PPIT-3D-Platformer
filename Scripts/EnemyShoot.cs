using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30.0f;
    public Coroutine fireCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Start firing
        fireCoroutine = StartCoroutine(FireCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        // Fire continuously at regular intervals
        FireCoroutine();
    }

    private IEnumerator FireCoroutine()
    {
        while(true)
        {
            // Fire left and right
            // instantiate bullet
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
           // give it position close to player
            bullet.transform.position = transform.position + new Vector3(1, 0, 0);
            // give it velocity and move right
            Rigidbody rbb = bullet.GetComponent<Rigidbody>();
            //rbb.velocity = new Vector2(1 * speed, 0);
            rbb.velocity = Vector2.right * bulletSpeed;



            // sleep for short time
            yield return new WaitForSeconds(0.5f); // pick a number!!!
        }
    }


}
