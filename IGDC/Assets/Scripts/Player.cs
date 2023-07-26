using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IThrowBall
{
    BallSpawner ballSpawner;
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        QualitySettings.pixelLightCount = 6;
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
        ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player specific throw abstract 
        #if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            Throw();
        }
        #endif
        
    }
    public void Throw()
    {
        ballSpawner.ThrowBall();
    }

}
