using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyScroll2 : MonoBehaviour
{
    public RawImage galaxy;
    private float increment = -2.5f;
    private float currPos;
    // Start is called before the first frame update
    void Start()
    {
        currPos = galaxy.transform.position.x;
    }
    
    void FixedUpdate()
    {

        if (currPos < -1400.5f)
        {
            increment = increment * -1;
        }

        currPos += increment;
        galaxy.transform.position = new Vector3(currPos, galaxy.transform.position.y, galaxy.transform.position.z);
    }
}
