using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugModeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if DEBUG
        Debug.Log("This is development build!");
#endif
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

