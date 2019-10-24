using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIndicator : MonoBehaviour
{
    public bool selected = false;
    private Vector2 grabDif;
    private float touchDownTime;
    private Vector2 touchDownPosition = Vector2.zero;
    public Vector2 startPosition;
    SpriteRenderer sprite;

    public PrejumpGameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.editMode) return;
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos = transform.position;
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if (selected)
        {
            transform.position = cursorPos - grabDif;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (sprite.bounds.Contains(cursorPos))
            {
                GetComponent<Collider2D>().enabled = false;
                Color semiTransparentColor = new Color(sp.color.r, sp.color.g, sp.color.b, 0.5f);
                sp.color = semiTransparentColor;
                selected = true;
                grabDif = cursorPos - pos;
                touchDownTime = Time.time;
                touchDownPosition = cursorPos;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (selected)
            {
                Color solidColor = new Color(sp.color.r, sp.color.g, sp.color.b, 1.0f);
                sp.color = solidColor;
                GetComponent<Collider2D>().enabled = true;
                selected = false;
            }
        }  
    }
}
