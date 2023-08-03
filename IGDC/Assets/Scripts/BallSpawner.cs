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

    public void ThrowBall(float strength,bool isThisPlayer,GameObject shooter)
    {
        GameObject ballInstance = Instantiate(ball,transform.position,Quaternion.identity) as GameObject;
        Rigidbody ballrb = ballInstance.GetComponent<Rigidbody>();
        ballrb.AddForce(transform.forward*ballSpeed*strength,ForceMode.Impulse);
        if(isThisPlayer) ballInstance.GetComponent<Ball>().isPlayer = true;
        ballInstance.GetComponent<Ball>().shootPerson = shooter;
    }

    public void ThrowBall(float strength)
    {
        GameObject ballInstance = Instantiate(ball,transform.position,Quaternion.identity) as GameObject;
        Rigidbody ballrb = ballInstance.GetComponent<Rigidbody>();
        ballrb.AddForce(transform.forward*ballSpeed*strength,ForceMode.Impulse);
    }

}
