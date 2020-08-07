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
                instance1.GetComponent<Bullet>().dir = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.right;
                yield return new WaitForSeconds(delay);
                StartCoroutine("InstGo", delay);
                yield return new WaitForSeconds(10.0f);
                Destroy(instance1);
                break;
            }
            case Mods.CHASING:
            {

                break;
            }
        }
    }
   
}
