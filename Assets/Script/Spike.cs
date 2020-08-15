using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject buttonObject;
    private Button button;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        button = buttonObject.GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if(button.is_checked == true)
        {
            this.tag = "Untagged";
            spriteRenderer.sprite = sprites[0];
        }
        else
        {
            this.tag = "Obstacle";
            spriteRenderer.sprite = sprites[1];
        }
    }
}
