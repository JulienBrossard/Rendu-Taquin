using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;
    [SerializeField] private GameObject resetButton;
    public GameObject continueButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject homeButton;
    [SerializeField] private GameObject pauseButton;

    private void Awake()
    {
        instance = this;
    }

    public void Reset() // Relancer le jeu
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void Home() // Revenir sur le Menu Home
    {
        SceneManager.LoadScene("Home");
    }

    public void Quit() // Quitte le jeu
    {
        Application.Quit();
    }

    public void Continue() // Continue le niveau
    {
        Time.timeScale = 1;
        quitButton.SetActive(false);
        homeButton.SetActive(false);
        resetButton.SetActive(false);
        continueButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Pause() // Met en pause
    {
        Time.timeScale = 0;
        quitButton.SetActive(true);
        homeButton.SetActive(true);
        resetButton.SetActive(true);
        continueButton.SetActive(true);
        pauseButton.SetActive(false);
    }
}
