using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxedInBox : MonoBehaviour
{
    public bool isSolid = false;
    public bool canToggle = true;
    public BoxedInGameController gameController;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        UpdateColorAndCollider();
    }

    bool cursorIn = false;
    // Update is called once per frame
    void Update()
    {
        if (!canToggle || gameController.isGameOver) return;
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonUp("Fire1")) {
            cursorIn = false;
        }
        if (Input.GetButtonDown("Fire1") && spriteRenderer.bounds.Contains(cursorPos)) {
            isSolid = !isSolid;
            UpdateColorAndCollider();
            cursorIn = true;
        }
        if (Input.GetButton("Fire1"))
        {
            if (spriteRenderer.bounds.Contains(cursorPos))
            {
                if (!cursorIn) {
                    isSolid = !isSolid;
                    UpdateColorAndCollider();
                    cursorIn = true;
                }
            } else {
                cursorIn = false;
            }
        }

    }

    void UpdateColorAndCollider() {
        if (isSolid)
        {
            boxCollider.enabled = true;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
        }
        else
        {
            boxCollider.enabled = false;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
        }
    }
}
