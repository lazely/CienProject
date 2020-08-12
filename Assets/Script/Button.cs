using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool is_checked;
    public bool special_stage = false;
    public float interv = 3f;
    void Start()
    {
        StartCoroutine("OnOff");
    }

    IEnumerator OnOff()
    {
        if (special_stage)
        {
            is_checked = is_checked ? false : true;
            if (is_checked == false)
            {
                yield return new WaitForSeconds(interv);
                interv = 4f;
                StartCoroutine("OnOff");
            }
            else
            {
                yield return new WaitForSeconds(interv);
                interv = 2f;
                StartCoroutine("OnOff");
            }
        }
        else
        {
            yield return new WaitForSeconds(interv);
            StartCoroutine("OnOff");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            is_checked = is_checked ? false : true;
        }
    }
}
