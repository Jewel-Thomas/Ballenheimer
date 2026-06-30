using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    public BallenheimerSceneManager.GameScene scene;
    public float changeSceneAfter;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(ChangeScene), changeSceneAfter);
    }

    public void ChangeScene()
    {
        BallenheimerSceneManager.Instance.LoadSceneSynchronous(scene);
    }

}
