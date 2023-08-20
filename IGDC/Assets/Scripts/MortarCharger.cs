using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MortarCharger : MonoBehaviour
{
    [SerializeField] float chargeTime;
    public float playerMortartimer;
    public float enemyMortartimer;
    [SerializeField] Image playerChargeAmount;
    [SerializeField] Image enemyChargeAmount;
    [SerializeField] MortarController playerMortarController;
    [SerializeField] MortarController enemyMortarController;
    public TextMeshProUGUI winnerText;
    public bool isThrown = false;
    public static bool isRedWinner = true;
    void Start()
    {
        isRedWinner = true;
        playerMortartimer = 0;
        playerChargeAmount.fillAmount = 0;
    }
    void Update()
    {
        ChargeUp();
        if(playerMortartimer>=chargeTime && !isThrown)
        {
            isRedWinner = true;
            playerMortarController.ThrowNuclearBomb();
            isThrown = true;
        }
        if(enemyMortartimer>=chargeTime && !isThrown)
        {
            isRedWinner = false;
            enemyMortarController.ThrowNuclearBomb();
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
