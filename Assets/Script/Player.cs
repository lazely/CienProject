using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance { get; private set; }
    public float speed = 10f;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0 || v != 0)
        {
            float angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;

            GetComponent<Rigidbody2D>().rotation = angle;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector3(h, v, 0f).normalized * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("게임오버 (" + collision.gameObject.name + "에 충돌)");
        }
        else if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("성공!");
        }
    }
}
