using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneAfterPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(ChangeScene),8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene()
    {
        SceneManager.LoadSceneAsync(5);
    }
}
