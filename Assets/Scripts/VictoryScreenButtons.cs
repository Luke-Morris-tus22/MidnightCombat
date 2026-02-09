using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreenButtons : MonoBehaviour
{
    public Button button;
    public Button button2;
    public Button button3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableButtons()
    {
        button.enabled = true;
        button2.enabled = true;
        button3.enabled = true;
    }

    public void disabelButtons()
    {
        button.enabled = false ;
        button2.enabled = false ;
        button3.enabled = false ;
    }

    public void OpenLink()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSdp11_vGiRBvCrrTrCO6ShLzmGy7vzYheMjB_suYoCzzS-3pg/viewform?usp=dialog");
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
