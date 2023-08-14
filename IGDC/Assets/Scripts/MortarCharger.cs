using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MortarCharger : MonoBehaviour
{
    [SerializeField] float chargeTime;
    public float playerMortartimer;
    public float enemyMortartimer;
    [SerializeField] Image playerChargeAmount;
    [SerializeField] Image enemyChargeAmount;
    [SerializeField] MortarController mortarController;
    public bool isThrown = false;
    void Start()
    {
        playerMortartimer = 0;
        playerChargeAmount.fillAmount = 0;
    }
    void Update()
    {
        ChargeUp();
        if(playerMortartimer>=chargeTime && !isThrown)
        {
            mortarController.ThrowNuclearBomb();
            isThrown = true;
        }
    }


    // Charges both the mortar with time
    void ChargeUp()
    {
        playerMortartimer+=Time.deltaTime;
        enemyMortartimer+=Time.deltaTime;
        playerMortartimer = Mathf.Clamp(playerMortartimer,0,chargeTime);
        enemyMortartimer = Mathf.Clamp(enemyMortartimer,0,chargeTime);
        playerChargeAmount.fillAmount = playerMortartimer/chargeTime;
        enemyChargeAmount.fillAmount = enemyMortartimer/chargeTime;
    }
}
