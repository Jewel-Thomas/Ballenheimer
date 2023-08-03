using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour
{
    [SerializeField] float destroyAfter = 10;
    Rigidbody ballRb;
    public bool isPlayer = false;
    public GameObject shootPerson;
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
            if(other.gameObject.CompareTag("Player") && isPlayer)
            {
                other.gameObject.GetComponent<PlayerAI>().warnText.text = $"Shoot the enemy you Drunkart @{shootPerson.name}";
                StartCoroutine(other.gameObject.GetComponent<PlayerAI>().WarnShooter());
            }
        }
        catch{

        }
        try{

            if(other.gameObject.CompareTag("Player") && !isPlayer)
            {
                float health = other.gameObject.GetComponent<Player>().GetHealth();
                GameObject parentObject = other.gameObject.GetComponent<Player>().parent;
                if(health<=0)
                {
                    Destroy(parentObject);
                }
                other.gameObject.GetComponent<Player>().TakeDamage(5);
                UIManager uIManager = other.gameObject.GetComponent<Player>().canvas.GetComponent<UIManager>(); 
                uIManager.ChangeColor();
            }
        }
        catch
        {

        }
        if(other.gameObject.CompareTag("AI") && isPlayer)
        {
            float health = other.gameObject.GetComponent<AIShooter>().GetHealth();
            if(health > 0)
            {
                other.gameObject.GetComponent<AIShooter>().TakeDamage(5);
            }
            else
            {
                other.gameObject.GetComponent<AIShooter>().CancelInvoke();
                other.gameObject.SetActive(false);
                Destroy(this.gameObject);
                ScoreManager.Instance.AddScore(5);
            }
        }
    }

}
