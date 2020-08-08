using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    ButtonManager button;
    void Start()
    {
        button = ButtonManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            button.is_checked = button.is_checked ? false : true;
        }
    }
}
