using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField] float destroyAfter = 10;
    Rigidbody ballRb;
    public bool isPlayer = false;
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
        if(other.gameObject.CompareTag("Player") && !isPlayer)
        {
            other.gameObject.GetComponent<Player>().TakeDamage(5);
            float health = other.gameObject.GetComponent<Player>().GetHealth();
            if(health<=0)
            {
                Destroy(other.gameObject);
            }
        }
        if(other.gameObject.CompareTag("AI") && isPlayer)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
