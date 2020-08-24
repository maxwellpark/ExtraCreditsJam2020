using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    public GameObject hitCursorPrefab;
    public GameObject missCursorPrefab;

    public Sprite cursorSprite;
    public Texture2D cursorTexture;

    public float zRotation;

    SpriteRenderer sr;

    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;


    float zRotationSpeed = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        //cursorSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Cursors/");
        Cursor.visible = false;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = cursorSprite; 
        //sr.sprite.
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;
        RotateCursor(); 
    }
    //void OnMouseEnter()
    //{
    //    //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    //}

    //void OnMouseExit()
    //{
    //    //Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //}

    void RotateCursor()
    {
        //transform.Rotate(0f, 0f, zRotation, Space.Self);
        //transform.Rotate(Quaternion.Euler(new Vector3(0f, 0f, zRotationSpeed)));

        transform.RotateAround(transform.position, Vector3.forward, zRotationSpeed * Time.deltaTime);
    }

    //void TexturiseSprites()
    //{
    //    //cursorSprite
    //    cursorTexture = new Texture2D((int)cursorSprite.rect.width, (int)cursorSprite.rect.height);
    //    var pixels = cursorSprite.texture.GetPixels((int)cursorSprite.textureRect.x,
    //                                                (int)cursorSprite.textureRect.y,
    //                                                (int)cursorSprite.textureRect.width,
    //                                                (int)cursorSprite.textureRect.height);
    //    cursorTexture.SetPixels(pixels);
    //    cursorTexture.Apply();
    //}
}