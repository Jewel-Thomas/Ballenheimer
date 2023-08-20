using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    string SceneName= "DodgeBall AI";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
