using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up, upleft, left, downleft, down, downright, right, upright
}

public class PlayerMovement : MonoBehaviour
{
    public Camera mainCamera;

    public float movementSpeed;
    public static Vector2 movement;
    public Vector3 mousePosition;


    void Start()
    {
        Cursor.visible = false; 
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); 
    }

    private void FixedUpdate()
    {
        // Reverse direction of vector 
        Vector3 headDirection = mousePosition - transform.position;

        // Angle between x axis and directional vector (x,y)
        float zAngle = Mathf.Atan2(headDirection.y, headDirection.x) * Mathf.Rad2Deg; // +/- 90f 

        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);

        Vector3 velocity = new Vector3(movement.x, movement.y, 0f);
        transform.position += velocity * movementSpeed * Time.fixedDeltaTime;
    }
}
