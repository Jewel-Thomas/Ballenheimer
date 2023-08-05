using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class AIShooter : MonoBehaviour,IThrowBall,Ihealth
{
    NavMeshAgent navMeshAgent;
    [Range(1,10000)] [SerializeField] float speed;
    [SerializeField] BallSpawner ballSpawner;
    [SerializeField] List<GameObject> targetList;
    [SerializeField] GameObject currentTarget;
    [SerializeField] GameObject player;
    Rigidbody rb;
    [SerializeField] float health = 100;
    [SerializeField] TextMeshProUGUI overText;
    public AudioClip shooterAIAudio;

    float randomTime;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        randomTime = Random.Range(0.5f,2);
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(Throw),randomTime,randomTime);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
        FindTarget();
        try{
            // Transform playerPos = player.transform;
            // navMeshAgent.destination = playerPos.position;
            overText.text = $"Health : {health}";
        }
        catch
        {
            navMeshAgent.enabled = false;
            CancelInvoke(nameof(Throw));
        }
    }

    void MoveTowardsTarget()
    {
        try{
            if(!currentTarget.activeInHierarchy && targetList!=null)
            {
                if(targetList.Count == 1) CancelInvoke();
                targetList.Remove(currentTarget);
            }
            if(targetList.Count==0)
            {
                CancelInvoke();
            }
            navMeshAgent.destination = currentTarget.transform.position;
        }
        catch{
            
        }
    }


    void FindTarget()
    {
        float min = Mathf.Infinity;
        foreach (var target in targetList)
        {
            if(Vector3.Distance(this.transform.position,target.transform.position) < min)
            {
                min = Vector3.Distance(this.transform.position,target.transform.position);
                currentTarget = target;
            }
        }
    }

    public void Throw()
    {
        float strength = Random.Range(2,10);
        ballSpawner.ThrowBall(strength);
    }
    public float GetHealth()
    {
        return health;
    }
    public void TakeDamage(float amount)
    {
        health-=amount;
    }
}
