using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public GameObject canon1;
    public GameObject canon2;

    public float xrotateSpeed = 10;
    public float zrotateSpeed = 10;
    public float moveSpeed = 10;
    public float focusSpeed = 10;

    float baseMoveSpeed;

    bool focusMode;

    public AudioSource playerHit;

    // Update is called once per frame

    private void Start()
    {
        baseMoveSpeed = moveSpeed;

        Cursor.visible = false;
    }
    void Update()
    {
        //Move

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Quaternion rotation = Quaternion.Euler(x, 0, z);

        transform.Rotate((-z * zrotateSpeed * Time.deltaTime), 0, (-x * xrotateSpeed * Time.deltaTime));

        Vector3 move = transform.forward;

        controller.Move(move * moveSpeed * Time.deltaTime);

        //Focus Mode
        
        if(Input.GetKey(KeyCode.Space))
        {
            focusMode = true;
        }
        else
        {
            focusMode = false;
        }

        if(focusMode)
        {
            moveSpeed = focusSpeed;
        }
        else
        {
            moveSpeed = baseMoveSpeed;
        }

        //Rotate canon too

        canon1.transform.Rotate(0, 0, (-z * xrotateSpeed * Time.deltaTime));
        canon2.transform.Rotate(0, 0, (-z * xrotateSpeed * Time.deltaTime));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("touché");
        }
    }
    
        

    
}
