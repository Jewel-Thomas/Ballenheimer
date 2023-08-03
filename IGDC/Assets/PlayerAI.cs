using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class PlayerAI : MonoBehaviour,IThrowBall,Ihealth
{
    [SerializeField] List<GameObject> targetList;
    [SerializeField] GameObject currentTarget;
    NavMeshAgent navMeshAgent;
    [SerializeField] BallSpawner ballSpawner;
    public TextMeshProUGUI warnText;
    [SerializeField] float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        float randomTime = Random.Range(0.5f,2);
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(Throw),randomTime,randomTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
        FindTarget();
        if(health <= 0)
        {
            Destroy(this.gameObject);
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
        float strength = Random.Range(2,5);
        ballSpawner.ThrowBall(strength,true,this.gameObject);
    }
    public void TakeDamage(float amount)
    {
        health-=amount;
    }

    public IEnumerator WarnShooter()
    {
        yield return new WaitForSeconds(2);
        warnText.text = "";
    }

}
