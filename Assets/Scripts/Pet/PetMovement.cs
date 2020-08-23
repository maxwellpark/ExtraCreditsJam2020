﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    public GameObject playerObject;

    public Sprite[] frameArray;
    public SpriteRenderer spriteRenderer;
    Vector3 mousePosition;
    Vector2 petDistance = new Vector2(0.75f, 0f);
    int currentFrame; 
    float timer;
    float frameRate = 0.2f; 

    void Start()
    {
        
    }

    void FixedUpdate()
    {
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

        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);

        Vector2 playerPosition = playerObject.transform.position;
        transform.position = playerPosition - petDistance;
    }
}
