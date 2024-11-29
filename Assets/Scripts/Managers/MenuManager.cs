using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject playerControlMenu;
    private bool isPaused = false;
    [SerializeField] private PlayerInputController inputManager;

    [Header("ProgressBar Display")]
    [SerializeField] Image progressBar;

    [SerializeField] public int activedRoom = 0;
    [SerializeField] private int maxRoom = 7;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;


        //DontDestroyOnLoad(gameObject);
    }

    public void DeterminePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        inputManager.InputActions.Player.PauseGame.performed += _ => DeterminePause();

       
        progressBar.fillAmount = Mathf.Clamp(2 / maxRoom, 0, 1);
    }


    private void OnDisable()
    {
        inputManager.InputActions.Player.PauseGame.performed -= _ => DeterminePause();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    // Resume the game
    public void ResumeGame()
    {
        if (pauseMenu == null)
        {
            return;
        }

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }
   

    public void GameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    private void HideControl()
    {
       
        playerControlMenu.SetActive(false);
    }

    private void ShowControl()
    {
        ResumeGame();
        playerControlMenu.SetActive(true);
    }
    void Update()
    {

        if (AnyPlayerInput())
        {
            HideControl();
        }

        //progress bar display
        if (activedRoom > 0)
        {
            progressBar.fillAmount = Mathf.Clamp((float)activedRoom / maxRoom, 0, 1);
        }
    }

    private bool AnyPlayerInput()
    {

        return Input.anyKeyDown;
    }



   

}
