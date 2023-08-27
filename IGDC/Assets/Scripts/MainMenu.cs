using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string SceneName= "DodgeBall AI";
    public GameObject MainMenuPan,Instructions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(SceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SeeControls()
    {
        MainMenuPan.SetActive(false);
        Instructions.SetActive(true);
    }
    public void closeButton()
    {
        Instructions.SetActive(false);
        MainMenuPan.SetActive(true);
    }
}
