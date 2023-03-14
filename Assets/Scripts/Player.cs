using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
public class Player : MonoBehaviour
{
    public delegate void PlayerDestroyed();
    public static event PlayerDestroyed OnPlayerDestroyed;
    public GameObject bulletPrefab;
    private float playerSpeed = 4.3f;
    public bool dead = false;
    public bool space = false;
    private Rigidbody player;
    private GameObject ship;
    public bool fired = false;

    //-----------------------------------------------------------------------------
    void Start()
    {
        ship = GameObject.Find("Ship");
        player = gameObject.GetComponent<Rigidbody>();
        Bullet.BulletDestroyed += bulletDestroyed;
        dead = false;
        ship.GetComponent<Animator>().SetBool("dead", dead);
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.velocity = new Vector3(playerSpeed, 0f, 0f);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.velocity = new Vector3(-playerSpeed, 0f, 0f);
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            player.velocity = new Vector3(0f, 0f, 0f);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && fired == false)
        {
            space = true;
            ship.GetComponent<Animator>().SetBool("space", space);
            fired = true;
            StartCoroutine(playShot());
        }

        if (GameHandler.GameOver == true)
        {
            StartCoroutine(playDeath());
        }
        
    }

    void bulletDestroyed()
    {
        fired = false;
        space = false;
    }

    IEnumerator playShot()
    {
        yield return new WaitForSeconds(0.25f);
        space = false;
        ship.GetComponent<Animator>().SetBool("space", space);
        GameObject shot = Instantiate(bulletPrefab, new Vector3(player.position.x, player.position.y + 0.5f, 5f), Quaternion.identity);
    }
    IEnumerator playDeath()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (!(other.gameObject.CompareTag("Wall")))
            {
                gameObject.GetComponent<AudioSource>().Play();
                dead = true;
                ship.GetComponent<Animator>().SetBool("dead", dead);
                GameHandler.GameOver = true;
                if (OnPlayerDestroyed != null) OnPlayerDestroyed.Invoke();
                StartCoroutine(playDeath());
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        {
            if (!(other.gameObject.CompareTag("Wall")))
            {
                gameObject.GetComponent<AudioSource>().Play();
                dead = true;
                GameHandler.GameOver = true;
                if (OnPlayerDestroyed != null) OnPlayerDestroyed.Invoke();
                StartCoroutine(playDeath());
            }
        }
    }
}
