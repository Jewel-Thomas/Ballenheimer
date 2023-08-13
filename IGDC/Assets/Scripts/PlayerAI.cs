using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class PlayerAI : MonoBehaviour,IThrowBall,Ihealth
{
    [SerializeField] GameObject currentTarget;
    NavMeshAgent navMeshAgent;
    [SerializeField] BallSpawner ballSpawner;
    public TextMeshProUGUI warnText;
    [SerializeField] float health;
    float totalHealth;
    public AudioClip playerAIAudio;
    public Image healthBar;
    public bool wasEmpty = true;
    public AISpawner aISpawner;

    // Start is called before the first frame update
    void Start()
    {
        aISpawner = FindObjectOfType<AISpawner>();
        totalHealth = health;
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
            UIManager.audioSource.PlayOneShot(playerAIAudio);
            CancelInvoke();
            gameObject.SetActive(false);
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = health/totalHealth;
    }

    void MoveTowardsTarget()
    {
        try{
            if(aISpawner.enemyAI.Count==0)
            {
                CancelInvoke();
                wasEmpty = true;
            }
            if(aISpawner.enemyAI.Count > 0 && wasEmpty)
            {
                float randomTime = Random.Range(0.5f,2);
                InvokeRepeating(nameof(Throw),randomTime,randomTime);
                wasEmpty = false;
            }
            if(!currentTarget.activeInHierarchy && aISpawner.enemyAI!=null)
            {
                // if(targetList.Count == 1) CancelInvoke();
                aISpawner.enemyAI.Remove(currentTarget);
            }
            navMeshAgent.destination = currentTarget.transform.position;
        }
        catch{
            
        }
    }

    void FindTarget()
    {
        float min = Mathf.Infinity;
        foreach (var target in aISpawner.enemyAI)
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
