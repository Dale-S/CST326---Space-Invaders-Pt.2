using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(creditTimer());
    }

    private IEnumerator creditTimer()
    {   yield return new WaitForSeconds(1);
        c1.SetActive(true);
        yield return new WaitForSeconds(1);
        c2.SetActive(true);
        yield return new WaitForSeconds(1);
        c3.SetActive(true);
        yield return new WaitForSeconds(1);
        c4.SetActive(true);
        yield return new WaitForSeconds(1);
        c5.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }
}
