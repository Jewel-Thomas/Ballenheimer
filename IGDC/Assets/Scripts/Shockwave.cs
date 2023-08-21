using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shockwave : MonoBehaviour
{
    //attributes of the shockwave which we can customize
    public int points;
    public float maxRadius;
    public float speed;
    public float startWidth;
    public float force;
    public float destroyIn = 1f;
    public static bool exploded;

    public static bool arebuttonsactive;

    private Animator nukeAnim;
    private Animator panelAnim;
    private TextMeshProUGUI winnerText_;
    
    
    private LineRenderer linerender;

    private void Awake()
    {
        exploded = false;
        nukeAnim = GetComponent<Animator>();
        linerender = GetComponent<LineRenderer>(); //sets the number of points for line renderer to make a circle
        linerender.positionCount = points + 1;
    }
    void Start()
    {
        panelAnim = FindObjectOfType<UIManager>().gameObject.GetComponent<Animator>();
        winnerText_ = FindObjectOfType<MortarCharger>().gameObject.GetComponent<MortarCharger>().winnerText;
        arebuttonsactive = false;
        StartCoroutine(Blast());
        StartCoroutine(LitUp());
        exploded = true;
        Destroy(this.gameObject,destroyIn);
    }
    private IEnumerator Blast() //responsible for blast effect
    {
        float currentRadius = 0f; // finds the current radius of shockwave
        GiveDamage(maxRadius);
        while(currentRadius < maxRadius)
        {
            currentRadius += Time.deltaTime * speed; //increases the radius till it reaches the target radius
            Draw(currentRadius);
            Damage(currentRadius);
            yield return null;
        }
    }
    private IEnumerator LitUp()
    {
        yield return new WaitForSeconds(2);
        nukeAnim.SetTrigger("LightStart");
        yield return new WaitForSeconds(1);
        panelAnim.SetTrigger("LightsAnim");
        yield return new WaitForSeconds(3);
        winnerText_.text = (MortarCharger.isRedWinner) ? "<color=red>RED Team </color>Wins" : "<color=blue>BLUE Team </color>Wins"; 
        yield return new WaitForSeconds(1);
        arebuttonsactive = true;


    }
    
    private void Damage(float currentRadius) //responsible for the force exerted on objects
    {
        Collider[] hittingObjects = Physics.OverlapSphere(transform.position, currentRadius);

        for(int i = 0; i < hittingObjects.Length; i++)
        {
            Rigidbody rb = hittingObjects[i].GetComponent<Rigidbody>();
            if(!rb)
            {
                continue;
            }
            Vector3 direction = (hittingObjects[i].transform.position - transform.position).normalized;
            rb.AddForce(direction * force, ForceMode.Impulse); //adds an impulse to every object that comes into contact
        }
    }

    private void GiveDamage(float damageRadius)
    {
        Collider[] hittingObjects = Physics.OverlapSphere(transform.position, damageRadius);
        for(int i=0;i<hittingObjects.Length;i++)
        {
            if(hittingObjects[i].gameObject.CompareTag("AI"))
            {
                float AIheath = hittingObjects[i].gameObject.GetComponent<AIShooter>().GetHealth();
                if(AIheath >= 30)
                {
                    hittingObjects[i].gameObject.GetComponent<AIShooter>().TakeDamage(30);
                    UIManager.blueHealth-=30;
                }
                else
                {
                    hittingObjects[i].gameObject.GetComponent<AIShooter>().TakeDamage(AIheath);
                    UIManager.blueHealth-=AIheath;
                }
            }
        }
    }


    private void Draw(float currentRadius) //responsible for drawing the shockwave
    {
        float anglebetween = 360f / points;

        for(int i=0; i <= points; i++) //in this part the shockwave travels with respect to the direction and position of the points
        {
            float angle = i * anglebetween * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f);
            Vector3 position = direction * currentRadius; 

            linerender.SetPosition(i, position); 
        }

        linerender.widthMultiplier = Mathf.Lerp(0f, startWidth, 1f - currentRadius/maxRadius);
    }

    private void Update()
    {
        //if(Input.GetKeyDown("space")) //Shockwave starts on pressing space
        //{
            
        //}
        
    }

}
