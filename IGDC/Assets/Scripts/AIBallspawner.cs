using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBallspawner : MonoBehaviour
{
    public GameObject ball;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float ballSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (timeBtwShots<- 0)
            {
                GameObject ballInstance = Instantiate(ball,transform.position,Quaternion.identity) as GameObject;
                Rigidbody ballrb = ballInstance.GetComponent<Rigidbody>();
                ballrb.AddForce(transform.forward*ballSpeed,ForceMode.Impulse);
                //Instantiate(ball, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots; 
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            } 
        
    }
}
