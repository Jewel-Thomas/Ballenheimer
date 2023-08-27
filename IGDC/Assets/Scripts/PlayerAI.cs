using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class PlayerAI : MonoBehaviour,IThrowBall,Ihealth
{
    [SerializeField] GameObject currentTarget;
    [SerializeField] int targetSetter;
    NavMeshAgent navMeshAgent;
    [SerializeField] BallSpawner ballSpawner;
    public TextMeshProUGUI warnText;
    [SerializeField] float health;
    float totalHealth;
    public AudioClip playerAIAudio;
    public Image healthBar;
    public bool wasEmpty = true;
    public AISpawner aISpawner;
    [SerializeField] Transform mortarTransform;
    [SerializeField] Vector3 startPos;
    [SerializeField] Animator characterAnim;
    private bool isDead;
    public static bool playerAITargetEquilizer = true;
    [SerializeField] static int targetCounter = 0;
    [SerializeField] int Check;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        startPos = transform.localPosition;
        if(playerAITargetEquilizer)
        {
            targetSetter = 1;
            playerAITargetEquilizer=!playerAITargetEquilizer;
            targetCounter++;
        }
        else
        {
            targetSetter = 0;
            playerAITargetEquilizer=!playerAITargetEquilizer;
            targetCounter--;
        }
        mortarTransform = GameObject.FindGameObjectWithTag("EMortar").transform;
        aISpawner = FindObjectOfType<AISpawner>();
        totalHealth = health;
        float randomTime = Random.Range(0.5f,2);
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(Throw),randomTime,randomTime);
    }

    // Update is called once per frame
    void Update()
    {
        Check = targetCounter;
        MoveTowardsTarget();
        FindTarget();
        if(health <= 0 && !isDead)
        {
            isDead = true;
            UIManager.audioSource.PlayOneShot(playerAIAudio);
            navMeshAgent.enabled = false;
            characterAnim.SetTrigger("Dead");
            if(targetCounter>0)
            {
                playerAITargetEquilizer=false;
                targetCounter--;
            }
            else if(targetCounter<0)
            {
                playerAITargetEquilizer=true;
                targetCounter++;
            }
            StartCoroutine(Respawn());
        }
        UpdateHealthBar();
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5);
        transform.localPosition = startPos;
        characterAnim.SetTrigger("Run");
        navMeshAgent.enabled = true;
        health = totalHealth;
        isDead = false;
        targetSetter = Random.Range(0,2);
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
            navMeshAgent.speed = 5;
            if(navMeshAgent.enabled)
            {
                if(targetSetter==0) navMeshAgent.destination = currentTarget.transform.position;
                else navMeshAgent.destination = mortarTransform.position;
            }
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                targetSetter=1;
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                targetSetter=0;
            }
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
