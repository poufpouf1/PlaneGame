using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [Header("Canon")]

    public GameObject canon1;
    public GameObject canon2;

    // Update is called once per frame
    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }

        canon1.transform.LookAt(transform.position);
        canon2.transform.LookAt(transform.position);
    }
}
