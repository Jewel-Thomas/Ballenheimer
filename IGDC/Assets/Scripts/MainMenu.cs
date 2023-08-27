using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    string SceneName= "DodgeBall AI";
    public GameObject MainMenuPan,Instructions;
    [SerializeField] Image loadingBar;
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
        StartCoroutine(LoadSceneAsynchronously(SceneName));
    }

    IEnumerator LoadSceneAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            loadingBar.fillAmount = progress;
            yield return null;
        }
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
