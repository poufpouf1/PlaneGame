using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceFrites : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform[] bulletSpawn;

    public float bulletSpeed = 30;

    public float fireRate = 0.5f;
    private float nextFire = 0f;

    public float rotationSpeed = 15;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }

        transform.parent.Rotate(0, 2 * rotationSpeed * Time.deltaTime, 0);
    }

    private void Fire()
    {
        //Spawn bullet on the bulletPoint
        for (int i = 0; i < bulletSpawn.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            bullet.transform.position = bulletSpawn[i].position;

            //Set bullet rotation

            Vector3 rotation = bulletSpawn[i].rotation.eulerAngles;

            bullet.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

            //Add force to bullet

            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn[i].forward * bulletSpeed, ForceMode.Impulse);
        }
    }
}
