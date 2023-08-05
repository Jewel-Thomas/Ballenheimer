using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public NukeCharge playercharge;
    // Start is called before the first frame update
    void Start()
    {
        //playercharge = GameObject.GetComponent<NukeCharge>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player" && playercharge.charge<=3)
        {
            Destroy(gameObject);
            playercharge.charge+=1;
        }
    }
}
