using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public interface IThrowBall{
    void Throw();
}
public class BallSpawner : MonoBehaviour
{
    // Getting reference to the ball prefab for network
    public GameObject ball;
    [SerializeField] float ballSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowBall()
    {
        GameObject ballInstance = Instantiate(ball,transform.position,Quaternion.identity) as GameObject;
        Rigidbody ballrb = ballInstance.GetComponent<Rigidbody>();
        ballrb.AddForce(transform.forward*ballSpeed,ForceMode.Impulse);
        ballInstance.GetComponent<Ball>().isPlayer = true;
    }

    public void ThrowBall(float strength)
    {
        GameObject ballInstance = Instantiate(ball,transform.position,Quaternion.identity) as GameObject;
        Rigidbody ballrb = ballInstance.GetComponent<Rigidbody>();
        ballrb.AddForce(transform.forward*ballSpeed*strength,ForceMode.Impulse);
    }

}
