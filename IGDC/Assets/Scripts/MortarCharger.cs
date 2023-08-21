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
    public static bool isExploded;
    public AudioSource audioSource;
    public AudioClip fireAudio;
    void Start()
    {
        isExploded = false;
        isRedWinner = true;
        isThrown = false;
        playerMortartimer = 0;
        playerChargeAmount.fillAmount = 0;
    }
    void Update()
    {
        ChargeUp();
        if(playerMortartimer>=chargeTime && !isThrown)
        {
            isExploded = true;
            isRedWinner = true;
            audioSource.PlayOneShot(fireAudio);
            playerMortarController.ThrowNuclearBomb();
            isThrown = true;
        }
        if(enemyMortartimer>=chargeTime && !isThrown)
        {
            isExploded = true;
            isRedWinner = false;
            audioSource.PlayOneShot(fireAudio);
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
