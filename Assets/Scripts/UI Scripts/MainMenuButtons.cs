using UnityEngine;
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
}
