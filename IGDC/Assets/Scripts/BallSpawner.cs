using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThrowBall{
    void Throw();
}
public class BallSpawner : MonoBehaviour
{
    // Getting reference to the ball prefab
    public GameObject ball,ball2, Counter;
    [SerializeField] float ballSpeed = 10;
    [SerializeField] float ball2_Speed = 20;
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
    }
    public void ThrowBall2()
    {
        GameObject ball2Instance = Instantiate(ball2,transform.position,Quaternion.identity) as GameObject;
        Rigidbody ball2rb = ball2Instance.GetComponent<Rigidbody>();
        ball2rb.AddForce(transform.forward*ball2_Speed,ForceMode.Impulse);
    }
    public void ActivateCounter()
    {
        GameObject counterInstance = Instantiate(Counter,transform.position,Quaternion.identity) as GameObject;
    }

}
