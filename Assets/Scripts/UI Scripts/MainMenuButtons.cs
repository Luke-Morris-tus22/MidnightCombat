using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject FightSelectMenu;
    public GameObject Credits;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FightSelectMenu.SetActive(false);
        Credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FightSelect()
    {
        FightSelectMenu?.SetActive(true);
    }

    public void CreditsSelect()
    {
        Credits?.SetActive(true);

    }

    public void CreditsSelectBack()
    {
        Credits.SetActive(false);

    }

    public void QuitSelect()
    {
        Application.Quit();
    }

    public void TutorialSelect()
    {
        SceneManager.LoadScene("Tutorial Fight");
    }

    public void RKSelect()
    {
        SceneManager.LoadScene("Rat King Fight");
    }

    public void FightSelectBack()
    {
        FightSelectMenu.SetActive(false);
    }

    public void OpenLink()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSdGJMNXrdWKaGAQhyERlWMQt8dN5eIUP9mr_dEpVVV7c4CbQA/viewform?usp=publish-editor");
    }

    public void selectButton(GameObject buttonToSelect)
    {
        EventSystem.current.SetSelectedGameObject(buttonToSelect);

    }

    public void deselectButtons()
    {
        EventSystem.current.SetSelectedGameObject(null);

    }
}
