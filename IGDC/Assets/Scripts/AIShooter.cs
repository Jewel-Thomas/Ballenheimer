using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIShooter : MonoBehaviour,IThrowBall
{
    NavMeshAgent navMeshAgent;
    [Range(1,10000)] [SerializeField] float speed;
    [SerializeField] BallSpawner ballSpawner;
    [SerializeField] GameObject player;
    Rigidbody rb;
    float randomTime;
    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(0.5f,2);
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(Throw),randomTime,randomTime);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        try{
            Transform playerPos = player.transform;
            navMeshAgent.destination = playerPos.position;
        }
        catch
        {
            navMeshAgent.enabled = false;
            CancelInvoke(nameof(Throw));
        }
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x,0,rb.velocity.z);
        if(flatVel.magnitude > speed)
        {
            Vector3 limitSpeed = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitSpeed.x,rb.velocity.y,limitSpeed.z);
        }
    }

    public void Throw()
    {
        float strength = Random.Range(2,10);
        ballSpawner.ThrowBall(strength);
    }
}
