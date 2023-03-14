using System;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private float speed = 6.5f;
    //-----------------------------------------------------------------------------
    void Start()
    {
        Fire();
        gameObject.GetComponent<AudioSource>().Play();
    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        GetComponent<Rigidbody>().velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!(collision.gameObject.CompareTag("Enemy")))
        {
            Destroy(this.gameObject);
        }
    }
}
