using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Button button;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        button = Button.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(button.is_checked == true)
        {
            col.enabled = false;
            spriteRenderer.sprite = sprites[0];
        }
        else
        {
            col.enabled = true;
            spriteRenderer.sprite = sprites[1];
        }
    }
}
