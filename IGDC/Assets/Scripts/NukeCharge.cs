using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeCharge : MonoBehaviour
{
    public int charge;
    public GameObject launchButton, Warhead;
    [SerializeField] float NukeSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(charge==3)
        {
            launchButton.SetActive(true);
        }
        if(charge<3)
        {
            launchButton.SetActive(false);
        }
    }

    public void LaunchNuke()
    {
        GameObject NukeInstance = Instantiate(Warhead,transform.position,Quaternion.identity) as GameObject;
        Rigidbody Nukerb = NukeInstance.GetComponent<Rigidbody>();
        Nukerb.AddForce(transform.forward*NukeSpeed,ForceMode.Impulse);
        charge = 0;
    }
}
