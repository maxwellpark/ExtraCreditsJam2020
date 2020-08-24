using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PetMovement : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject pivotObject;
    public GameObject cameraObject; 
    public Camera mainCamera; 

    public Sprite[] frameArray;
    public SpriteRenderer spriteRenderer;

    Vector3 mousePosition;
    Vector2 petDistance = new Vector2(0.75f, 0f);

    int currentFrame; 
    float timer;
    float frameRate = 0.2f; 

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); 
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera = cameraObject.GetComponent<Camera>(); 
        //Debug.Log("Pet position:" + transform.position);
        //Debug.Log("Pivot position: " + pivotObject.transform.position);
    }

    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        // break this sprite anim code out 
        timer += Time.fixedDeltaTime;

        if (timer >= frameRate)
        {
            timer -= frameRate;

            // Reset currentFrame to 0 when it reaches the length of the array 
            currentFrame = (currentFrame + 1) % frameArray.Length;

            // Update the sprite being rendered 
            spriteRenderer.sprite = frameArray[currentFrame];
        }

        // Reverse direction of vector 
        Vector3 headDirection = mousePosition - transform.position;

        // Angle between x axis and directional vector (x,y)
        float zAngle = Mathf.Atan2(headDirection.y, headDirection.x) * Mathf.Rad2Deg + -90f; // +/- 90f 

        //transform.rotation = Quaternion.Euler(0f, 0f, zAngle);

        // player or pet? 
        //Quaternion oldRotation = transform.rotation; 
        Quaternion oldRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Quaternion newRotation = Quaternion.Euler(0f, 0f, zAngle);
        float difference = oldRotation.z - newRotation.z;

        // stableish experiment 
        transform.localRotation = Quaternion.Euler(0f, 0f, zAngle);
        //transform.RotateAround(pivotObject.transform.position, Vector3.right, difference);

        // new go:
        //transform.Rotate(new Vector3(newRotation.x, newRotation.y, newRotation.z), Space.Self);

        //Vector3 newRotation = new Vector3(0f, 0f, 10f);
        //transform.Rotate(newRotation.x, newRotation.y, newRotation.z, Space.World);
        //transform.RotateAround(playerObject.transform.position, Vector3.forward, 1f);

        //transform.RotateAround(transform.position, Vector3.forward, 15f); 

        Vector2 playerPosition = playerObject.transform.position;
        transform.position = playerPosition - petDistance;
    }

    void RotatePet()
    {
        //transform.RotateAround(transform.position, -Vector2.left, )
    }
}
