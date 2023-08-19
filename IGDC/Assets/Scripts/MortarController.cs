using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MortarController : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Place the nuclear ball prefab in here")]
    public GameObject nuclearCorePrefab;
    [SerializeField] float speed; 
    [Header("Keybidings")]
    [Space]
    [SerializeField] KeyCode bombKey = KeyCode.B;
    [Header("Animations")]
    [Space]
    [SerializeField] Animator mortarAnimator;
    [SerializeField] Animator lightAnim;
    [Header("UI")]
    [Space]
    [SerializeField] Slider rotationSlider;
    public MortarCharger mortarCharger;
    void Start()
    {
        mortarAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(bombKey))
        {
            ThrowNuclearBomb();
        }
        // RotateMortarHead();
    }

    public void ThrowNuclearBomb()
    {
        GameObject bomb = Instantiate(nuclearCorePrefab,transform.position,Quaternion.identity) as GameObject;
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
        if(gameObject.CompareTag("PMortar"))
        {
            bombRb.AddForce(transform.up*speed*2f,ForceMode.Impulse);
            mortarAnimator.SetTrigger("MortarAnim");
            // lightAnim.SetTrigger("LightsAnim");
        }
        if(gameObject.CompareTag("EMortar"))
        {
            bombRb.AddForce(transform.forward*speed*2f,ForceMode.Impulse);
            mortarAnimator.SetTrigger("EnemyShot");
            // lightAnim.SetTrigger("LightsAnim");
        }
    }

    void RotateMortarHead()
    {
        float rotateAmount = rotationSlider.value*30;
        transform.rotation = Quaternion.Euler(rotateAmount,transform.rotation.y,transform.rotation.z);
    }
}
