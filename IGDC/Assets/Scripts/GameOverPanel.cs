using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    string SceneName= "DodgeBall AI";
    public GameObject gameManager;
    public GameObject player;
    public UIManager uIManager;
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
        Shockwave.arebuttonsactive = false;
        Destroy(gameManager);
        player.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
