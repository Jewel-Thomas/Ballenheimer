using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform stand;

    private float mouseX, mouseY;
    public float stomachOffset;
    public ConfigurableJoint pelvisJoint, stomachJoint;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        Quaternion rootRotation = Quaternion.Euler(mouseY, mouseX, 0);

        stand.rotation = rootRotation;
        pelvisJoint.targetRotation = (Quaternion.Euler(mouseX, 0, 0));
        stomachJoint.targetRotation = Quaternion.Euler(0, 0, mouseY + stomachOffset);
    }

}
