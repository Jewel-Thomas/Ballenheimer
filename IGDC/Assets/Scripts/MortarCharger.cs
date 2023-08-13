using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MortarCharger : MonoBehaviour
{
    [SerializeField] float chargeTime;
    public float timer;
    [SerializeField] Image chargeAmount;
    [SerializeField] MortarController mortarController;
    public bool isThrown = false;
    void Start()
    {
        timer = 0;
        chargeAmount.fillAmount = 0;
    }
    void Update()
    {
        ChargeUp();
        if(timer>=chargeTime && !isThrown)
        {
            mortarController.ThrowNuclearBomb();
            isThrown = true;
        }
    }

    void ChargeUp()
    {
        timer+=Time.deltaTime;
        timer = Mathf.Clamp(timer,0,chargeTime);
        chargeAmount.fillAmount = timer/chargeTime;
    }
}
