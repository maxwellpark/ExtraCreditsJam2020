using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerObject;
    public Collider roomCollider; 

    private float cameraDistance = 2.0f;
    private float elevation; 

    private void Start()
    {
        CenterCamera(); 
    }

    private void Update()
    {

    }

    private void CenterCamera()
    {
        Vector3 objectSizes = roomCollider.bounds.max - roomCollider.bounds.min;
        float objectSize = Mathf.Max(objectSizes.x, objectSizes.y, objectSizes.z);

        // Visible height is 1 metre in front
        float cameraView = 2.0f * Mathf.Tan(0.5f * Mathf.Deg2Rad * Camera.main.fieldOfView);

        // Combined wanted distance from the object
        float distance = cameraDistance * objectSize / cameraView;

        // Estimated offset from the center to the outside of the object
        distance += 0.5f * objectSize; 
        Camera.main.transform.position = roomCollider.bounds.center - distance * Camera.main.transform.forward;
        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(elevation, 0, 0));
    }


}

