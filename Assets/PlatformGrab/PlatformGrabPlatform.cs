using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGrabPlatform : MonoBehaviour
{
    public bool selected = false;
    private Vector2 grabDif;
    private float touchDownTime;
    private Vector2 touchDownPosition = Vector2.zero;
    int prevSortingOrder = 0;
    public Vector2 startPosition;
    SpriteRenderer sprite;

    public PlatformGrabGameController gameController;
    // public GameController gameController;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isGameOver) { return; }
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 cardPos = transform.position;
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if (selected)
        {
            transform.position = cursorPos - grabDif;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (gameController.isGrabbingOne) { return; }
            if (sprite.bounds.Contains(cursorPos))
            {
                GetComponent<Collider2D>().enabled = false;
                Color semiTransparentColor = new Color(sp.color.r, sp.color.g, sp.color.b, 0.5f);
                sp.color = semiTransparentColor;
                selected = true;
                grabDif = cursorPos - cardPos;
                touchDownTime = Time.time;
                touchDownPosition = cursorPos;
                gameController.isGrabbingOne = true;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (selected)
            {
                Color solidColor = new Color(sp.color.r, sp.color.g, sp.color.b, 1.0f);
                sp.color = solidColor;
                GetComponent<Collider2D>().enabled = true;
                gameController.isGrabbingOne = false;
                selected = false;
            }
        }  
    }
}
