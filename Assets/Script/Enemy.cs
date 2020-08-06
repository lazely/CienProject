using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Bullet;
    enum Mods {STATIC, CHASING};
    private Mods mods = Mods.STATIC;
    public float interv = 3.0f;
    // Start is called before the first frame update
    
    void Start()
    {
        StartCoroutine("InstGo", interv);
    }

    IEnumerator InstGo(float delay)
    {
        switch (mods)
        {
            case Mods.STATIC:
            {
            GameObject instance1 = Instantiate(Bullet, transform.position, transform.rotation);
                instance1.GetComponent<Bullet>().dir = Vector3.up;
                GameObject instance2 = Instantiate(Bullet, transform.position, transform.rotation);
                instance2.GetComponent<Bullet>().dir = Vector3.down;
                GameObject instance3 = Instantiate(Bullet, transform.position, transform.rotation);
                instance3.GetComponent<Bullet>().dir = Vector3.left;
                GameObject instance4 = Instantiate(Bullet, transform.position, transform.rotation);
                instance4.GetComponent<Bullet>().dir = Vector3.right;
                yield return new WaitForSeconds(delay);
                StartCoroutine("InstGo", delay);
                yield return new WaitForSeconds(10.0f);
                Destroy(instance1);
                Destroy(instance2);
                Destroy(instance3);
                Destroy(instance4);
                break;
            }
            case Mods.CHASING:
            {

                break;
            }
        }
    }
   
}
