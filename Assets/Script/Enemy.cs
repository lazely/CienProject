using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    public GameObject Bullet;
    public enum Mods {STATIC,AUTO,CHASING};
    public Mods mods = Mods.STATIC;
    public float firerates = 0.2f;
    public float interv = 3.0f;
    // Start is called before the first frame update
    
    void Start()
    {
        player = Player.instance;
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
            case Mods.AUTO:
            {
                GameObject instance1 = Instantiate(Bullet, transform.position, transform.rotation);
                instance1.GetComponent<Bullet>().dir = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.right;
                yield return new WaitForSeconds(firerates);
                GameObject instance2 = Instantiate(Bullet, transform.position, transform.rotation);
                instance2.GetComponent<Bullet>().dir = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.right;

                yield return new WaitForSeconds(delay);
                StartCoroutine("InstGo", delay);
                yield return new WaitForSeconds(10.0f);
                Destroy(instance2);
                Destroy(instance1);    
                break;
            }
            case Mods.CHASING:
            {
                Vector3 dir = player.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    GameObject instance1 = Instantiate(Bullet, transform.position, transform.rotation);
                instance1.GetComponent<Bullet>().dir = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.right;
                yield return new WaitForSeconds(delay);
                StartCoroutine("InstGo", delay);
                yield return new WaitForSeconds(10.0f);       
                Destroy(instance1);

                    break;
            }
        }
    }
   
}
