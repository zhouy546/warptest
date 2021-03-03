﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Display.displays.Length > 1)
        {
            for (int i = 1; i < Display.displays.Length; i++)
            {
                Display.displays[i].Activate();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
