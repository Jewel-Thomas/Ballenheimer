using System.Collections;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI fpsText;
    private float deltaTime = 0.0f;
    [SerializeField] private AudioSource bgm;
    public bool isPaused = false;
    public bool isover = false;
    [SerializeField] private GameObject pausedPanel, gameoverPan;
    [SerializeField] private GameObject otherUI;
    [SerializeField] private CapsuleCollider capsuleCollider;
    public AudioSource audioSource;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Animator canvasAnim;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        canvasAnim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioSource = bgm;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateFPS();
        if(Input.GetKeyDown(KeyCode.Escape) && !isover && !CountDown.isCountingDown)
        {
            isPaused = !isPaused;
            SetPauseState(isPaused);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            canvasAnim.SetTrigger("Key1");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            canvasAnim.SetTrigger("Key2");
        }
    }

    void CalculateFPS()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
        fpsText.text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    }

    void SetPauseState(bool isPaused)
    {
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Time.timeScale = isPaused ? 0 : 1;
        if (isPaused)
        {
            bgm.Pause();
        }
        else
        {
            bgm.Play();
        }
        pausedPanel.SetActive(isPaused);
        otherUI.SetActive(!isPaused);
    }

    public void HandleHealthText(float currentHealth, TextMeshProUGUI healthText)
    {
        Color tempColor = Color.black;
        tempColor.r = (100 - currentHealth) / 100;    // Increases the red color as the health goes down
        tempColor.g = currentHealth / 100;
        healthText.text = $"Health : {currentHealth}";
        healthText.color = tempColor;
    }

    public void SetGameOverState(bool isGameOver)
    {
        Cursor.visible = isGameOver;
        Cursor.lockState = isGameOver ? CursorLockMode.None : CursorLockMode.Locked;
        otherUI.SetActive(!isGameOver);
        pausedPanel.SetActive(!isGameOver);
        isover = isGameOver;
        player.enabled = !isGameOver;
        gameoverPan.SetActive(isGameOver);
        capsuleCollider.enabled = !isGameOver;
        scoreManager.enabled = !isGameOver;
        MortarCharger.isThrown = isGameOver;
    }

    public IEnumerator ScaleTime(float start, float end, float time) 
    {
	    float lastTime = Time.realtimeSinceStartup;
	    float timer = 0.0f;
        //Time.fixedDeltaTime = Time.timeScale * 0.02f;
	    while (timer < time) 
        {
		    Time.timeScale = Mathf.Lerp (start, end, timer / time);
		    timer += (Time.realtimeSinceStartup - lastTime);
		    lastTime = Time.realtimeSinceStartup;
            Time.fixedDeltaTime = Time.timeScale;
		    yield return null;
	    }
	
	    Time.timeScale = end;
        gameoverPan.SetActive(true);	
    }
}
