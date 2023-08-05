using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public GameObject CatchScreen;
    bool catching = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCatch()
    {
        catching = true;
        CatchScreen.SetActive(true);
    }
    public void ReleaseCatch()
    {
        catching = false;
        CatchScreen.SetActive(false);
    }
}
