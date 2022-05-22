using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFrites : MonoBehaviour
{
    public GameObject rotator; 
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    //private void Update()
    //{
        //transform.RotateAround(rotator.transform.position, Vector3.up, 20 * Time.deltaTime);
    //}
}
