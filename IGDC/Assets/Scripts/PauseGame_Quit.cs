using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame_Quit : MonoBehaviour
{
    
    // Update is called once per frame
    public void OnApplicationQuit(){
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
