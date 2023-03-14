using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaivor : MonoBehaviour
{
    private int health = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.CompareTag("Shield")))
        {
            health += -1;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!(collision.gameObject.CompareTag("Shield")))
        {
            health += -1;
        }
    }
}
