using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    private string mainGame = "mainGame";
    private string credit = "credits";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadGameScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void game()
    {
        LoadGameScene(mainGame);
    }
    
    public void credits()
    {
        LoadGameScene(credit);
    }
}
