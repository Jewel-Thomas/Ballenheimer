using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour
{
    [SerializeField] float destroyAfter = 10;
    Rigidbody ballRb;
    public bool isPlayer = false;
    public GameObject shootPerson;
    [SerializeField] GameObject PlayerUI;
    UIManager uimanger;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject,destroyAfter);
    }

    void OnCollisionEnter(Collision other)
    {
       
        try{

            if(other.gameObject.CompareTag("Player") && !isPlayer)
            {
                try{
                    float health = other.gameObject.GetComponent<Player>().GetHealth();
                    GameObject parentObject = other.gameObject.GetComponent<Player>().parent;
                    other.gameObject.GetComponent<Player>().TakeDamage(5);
                    UIManager.redHealth-=5;
                    UIManager uIManager = other.gameObject.GetComponent<Player>().canvas.GetComponent<UIManager>(); 
                    uIManager.ChangeColor();
                    if(health<5)
                    {
                        uIManager.GameOver();
                        UIManager.audioSource.PlayOneShot(other.gameObject.GetComponent<Player>().playerAudio);
                        //parentObject.SetActive(false);
                    }
                }
                catch{
                    other.gameObject.GetComponent<PlayerAI>().TakeDamage(5);
                    UIManager.redHealth-=5;
                }
            }
        }
        catch {}
        if(other.gameObject.CompareTag("AI") && isPlayer)
        {
            float health = other.gameObject.GetComponent<AIShooter>().GetHealth();
            if(health > 0)
            {
                other.gameObject.GetComponent<AIShooter>().TakeDamage(5);
                health = other.gameObject.GetComponent<AIShooter>().GetHealth();
                UIManager.blueHealth-=5;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PMortar") && !isPlayer)
        {
            other.GetComponent<MortarController>().mortarCharger.playerMortartimer-=2;
        }
        if(other.gameObject.CompareTag("EMortar") && isPlayer)
        {
            other.GetComponent<MortarController>().mortarCharger.enemyMortartimer-=2;
        }
    }



}
