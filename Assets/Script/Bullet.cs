using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 dir = new Vector3 (0f,0f,0f);
    public float speed = 10.0f;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (is_pene == false && collision.gameObject.tag != "Obstacle") Destroy(this.gameObject);
    }
}
