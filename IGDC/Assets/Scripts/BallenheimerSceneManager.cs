using UnityEngine;
using UnityEngine.SceneManagement;

public class BallenheimerSceneManager : MonoBehaviour
{
    public static BallenheimerSceneManager Instance { get; private set; }

    public enum GameScene
    {
        LogoScene,
        NarrationScene,
        MainMenu,
        MainScene,
        BlueWinner,
        RedWinner
    }

    private void Awake()
    {
        if(Instance && Instance!=this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadSceneSynchronous(GameScene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public AsyncOperation LoadSceneAsynchronous(GameScene scene)
    {
        return SceneManager.LoadSceneAsync(scene.ToString());
    }
}
