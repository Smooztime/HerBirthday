using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject playerControlMenu;
    private bool isPaused = false;
    [SerializeField] private PlayerInputController inputManager;


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
    }


    private void OnDisable()
    {
        inputManager.InputActions.Player.PauseGame.performed -= _ => DeterminePause();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
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
    }

    private bool AnyPlayerInput()
    {

        return Input.anyKeyDown;
    }

}
