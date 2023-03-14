using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public int numOfEnemies = 20;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public Transform enemyRoot;
    public GameObject shield;
    public GameObject player;
    //public static int lives = 3; //Commented out because it wasn't required and was causing bugs
    public static bool GameOver = false;
    public GameObject over;
    public GameObject win;
    private bool debounce = true;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startUp());
        StartCoroutine(waitForSpawn());
        Enemy.WallHit += OnWallHit;
        Enemy.WallLeft += OnWallLeave;
    }

    public void startGame()
    {
        Enemy.down = 0;
        Enemy.speed = 1.9f;
        over.SetActive(false);
        for(int i = 0; i < numOfEnemies; i++)
        { 
            GameObject newEnemy = Instantiate(enemy1, new Vector3(-7f + (0.5f * i), 8.5f, 5f), new Quaternion(0f, 90f, 0f,0f));
            newEnemy.transform.parent = enemyRoot;
        }
        for(int i = 0; i < numOfEnemies; i++)
        { 
            GameObject newEnemy = Instantiate(enemy2, new Vector3(-7f + (0.5f * i), 7.75f, 5f), new Quaternion(0f, 90f, 0f,0f));
            newEnemy.transform.parent = enemyRoot;
        }
        for(int i = 0; i < numOfEnemies; i++)
        { 
            GameObject newEnemy = Instantiate(enemy2, new Vector3(-7f + (0.5f * i), 7f, 5f), new Quaternion(0f, 90f, 0f,0f));
            newEnemy.transform.parent = enemyRoot;
        }
        for(int i = 0; i < numOfEnemies; i++)
        { 
            GameObject newEnemy = Instantiate(enemy3, new Vector3(-7f + (0.5f * i), 6.25f, 5f), new Quaternion(0f, 90f, 0f,0f));
            newEnemy.transform.parent = enemyRoot;
        }
        for(int i = 0; i < numOfEnemies; i++)
        { 
            GameObject newEnemy = Instantiate(enemy3, new Vector3(-7f + (0.5f * i), 5.5f, 5f), new Quaternion(0f, 90f, 0f,0f));
            newEnemy.transform.parent = enemyRoot;
        }

        for (int i = 0; i < 4; i++)
        {
            Instantiate(shield, new Vector3(0 + (5 * i), 6f, 5f), new Quaternion(0f,0f,0f,0f));
        }

        Instantiate(player, new Vector3(0f, 0.5f, 5f), new Quaternion(0f, 90f, 0f, 0f));
    }
    
    private IEnumerator startUp()
    {
        GameOver = false;
        yield return new WaitForSeconds(1);
        startGame();
    }

    private IEnumerator waitForSpawn()
    {
        yield return new WaitForSeconds(5);
        spawned = true;
    }

    public void OnWallHit()
    {
        if (debounce == true)
        {
            Debug.Log("Enemy Hit A Wall");
            dropDown();
            Enemy.direction = !(Enemy.direction);
            debounce = false;
        }
    }

    public void OnWallLeave()
    {
        Debug.Log("Enemy Left The Wall");
        debounce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned == true && enemyRoot.childCount == 0)
        {
            win.SetActive(true);
            StartCoroutine(gameEnd());
        }

        if (GameOver == true)
        {
            playerDestroyed();
        }
    }
    
    private void dropDown()
    {
        Enemy.heightUpdate = true;
        Enemy.down = Enemy.down - 0.20f;
        Enemy.speed += -0.05f;
    }

    private void playerDestroyed()
    {
        over.SetActive(true);
        StartCoroutine(gameEnd());
    }

    IEnumerator gameEnd()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("credits", LoadSceneMode.Single);
    }
}
