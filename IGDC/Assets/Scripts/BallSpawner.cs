using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Getting reference to the ball prefab
    public GameObject ball;
    [SerializeField] float ballSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Throws a ball forward when the mouse button is clicked
        #if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            ThrowBall();
        }
        #endif
    }

    public void ThrowBall()
    {
        GameObject ballInstance = Instantiate(ball,transform.position,Quaternion.identity) as GameObject;
        Rigidbody ballrb = ballInstance.GetComponent<Rigidbody>();
        ballrb.AddForce(transform.forward*ballSpeed,ForceMode.Impulse);
    }

}
