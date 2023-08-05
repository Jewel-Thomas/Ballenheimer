using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warhead : MonoBehaviour
{
    public GameObject detonation;
    public float destroyIn = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if(!col.gameObject.CompareTag("Player"))
        {
            GameObject warheadInstance = Instantiate(detonation,transform.position,Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
        }

    }
}
