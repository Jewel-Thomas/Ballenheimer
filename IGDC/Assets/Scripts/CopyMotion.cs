using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform targetLimb;
    private ConfigurableJoint configurableJoint;
    private Quaternion startRot;
    public bool inverse;
    
    void Start()
    {
        configurableJoint = GetComponent<ConfigurableJoint>();
        startRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(!inverse) configurableJoint.targetRotation = targetLimb.localRotation * startRot;
        else configurableJoint.targetRotation = Quaternion.Inverse(targetLimb.localRotation) * startRot;
        
    }
}
