using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 6.5f;
    public delegate void shotFired();
    public static event shotFired BulletDestroyed;
    //-----------------------------------------------------------------------------
    void Start()
    {
        Fire();
        gameObject.GetComponent<AudioSource>().Play();
    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        GetComponent<Rigidbody>().velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BulletDestroyed.Invoke();
        Destroy(this.gameObject);
    }
}
