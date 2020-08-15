using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 dir = new Vector3 (0f,0f,0f);
    public float speed = 50.0f;
    public bool is_pene = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (is_pene != true && collision.gameObject.tag == "Wall") Destroy(this.gameObject);
    }
}
