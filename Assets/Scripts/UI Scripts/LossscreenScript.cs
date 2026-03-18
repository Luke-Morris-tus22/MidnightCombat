using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LossscreenScript : MonoBehaviour
{
    private Animator _animator;
    public Button RetryButton;
    public Button QuitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        RetryButton.interactable = false;
        QuitButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LossScreenStart()
    {
        _animator.SetTrigger("Open");
        RetryButton.interactable = true;
        QuitButton.interactable = true;
        RetryButton.Select();
    } 

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitLevel()
    {

    }
}
