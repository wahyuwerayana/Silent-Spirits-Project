using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject creditsCanvas;

    private void Start()
    {
        ShowMainMenu();  
    }

    public void PlayGame()
    {
        Debug.Log("Play button clicked");
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("Beach");
    }

    public void ShowCredits()
    {
        Debug.Log("Credits button clicked");
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void ShowMainMenu()
    {
        Debug.Log("Back to Main Menu button clicked");
        mainMenuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}
