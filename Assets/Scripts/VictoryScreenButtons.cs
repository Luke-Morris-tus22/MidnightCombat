using UnityEngine;
using UnityEngine.SceneManagement;

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
        Application.OpenURL("https://www.google.com");
    }

    public void RestartPlaytest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
