using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public GameObject ball,bot;
    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float ballSpeed = 10;

    public bool movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement==true)
        {
            if(Vector3.Distance(transform.position, player.position) > stoppingDistance) 
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }   
            else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
            /*if (timeBtwShots<- 0)
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
            } */
        }

    }   

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "enemyplat")
        {
            movement=true;
        } 
        else
        {
            movement=false;
        }
    }
        
}
