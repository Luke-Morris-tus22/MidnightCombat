using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreenButtons : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLink()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSdGJMNXrdWKaGAQhyERlWMQt8dN5eIUP9mr_dEpVVV7c4CbQA/viewform?usp=publish-editor");
    }

    public void RestartPlaytest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void StartRKFight()
    {
        SceneManager.LoadScene("Rat King Fight");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
