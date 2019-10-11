using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// cool website for checking color blindness http://www.color-blindness.com/coblis-color-blindness-simulator/

public class AlchemyObject : MonoBehaviour
{
    public Sprite rockSprite;
    public Sprite waterSprite;
    public Sprite gemSprite;

    public int color = 0;
    public float size = 0;
    public int currentSprite = 1;

    public AlchemyGameController gameController;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = rockSprite;
        Invoke("StartTimer", 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ResetObject()
    {
        sr.color = Color.white;
        color = 0;
        sr.sprite = rockSprite;
        currentSprite = 1;
        transform.localScale = new Vector3 (1, 1, 1);
    }

    public void ColorGreen() {
        if (gameController.isGameOver) return;
        sr.color = Color.green;
        color = 1;
        gameController.ObjectChanged();
    }

    public void ColorRed() {
        if (gameController.isGameOver) return;
        sr.color = Color.red;
        color = 2;
        gameController.ObjectChanged();
    }

    public void ColorBlue() {
        if (gameController.isGameOver) return;
        sr.color = Color.cyan;
        color = 3;
        gameController.ObjectChanged();
    }

    public void Grow() {
        if (gameController.isGameOver) return;
        transform.localScale *= 1.2f;
        size = transform.localScale.magnitude;
        gameController.ObjectChanged();
    }

    public void Shrink() {
        if (gameController.isGameOver) return;
        transform.localScale /= 1.2f;
        size = transform.localScale.magnitude;
        gameController.ObjectChanged();
    }

    public void Transform() {
        if (gameController.isGameOver) return;
        if (sr.sprite == rockSprite) {
            sr.sprite = waterSprite;
            currentSprite = 2;
        } else if (sr.sprite == waterSprite) {
            sr.sprite = gemSprite;
            currentSprite = 3;
        } else {
            sr.sprite = rockSprite;
            currentSprite = 1;
        }
        gameController.ObjectChanged();
    }
}
