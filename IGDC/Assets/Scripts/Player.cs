using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IThrowBall
{
    BallSpawner ballSpawner;
    // Start is called before the first frame update
    void Start()
    {
        ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
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
