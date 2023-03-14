using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyScroll : MonoBehaviour
{
    public RawImage galaxy;
    private float increment = -0.001f;
    private float currPos;
    // Start is called before the first frame update
    void Start()
    {
        currPos = galaxy.transform.position.x;
    }
    
    void FixedUpdate()
    {
        if (currPos > 4.4f)
        {
            increment = increment * -1;
        }

        if (currPos < -4.5f)
        {
            increment = increment * -1;
        }

        currPos += increment;
        galaxy.transform.position = new Vector3(currPos, galaxy.transform.position.y, galaxy.transform.position.z);
    }
}
