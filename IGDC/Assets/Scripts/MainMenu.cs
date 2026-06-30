using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private string SceneName;
    public GameObject MainMenuPan,Instructions;
    [SerializeField] Image loadingBar;

    public void PlayGame()
    {
        StartCoroutine(LoadSceneAsynchronously(SceneName));
    }

    IEnumerator LoadSceneAsynchronously(string scene)
    {
        AsyncOperation operation = BallenheimerSceneManager.Instance.LoadSceneAsynchronous(BallenheimerSceneManager.GameScene.MainScene);
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
