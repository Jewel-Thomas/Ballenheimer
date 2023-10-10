using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<ScoreManager>().gameObject;
        Destroy(gameManager);
        Invoke(nameof(GotoMainMenu),30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkipButton()
    {
        SceneManager.LoadScene(1);
    }

    void GotoMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
