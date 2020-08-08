using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    static public ButtonManager instance { get; private set; }
    public bool is_checked = false;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
}
