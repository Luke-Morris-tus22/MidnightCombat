using StarterAssets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public Sprite[] numbers;
    public int counter;
    public Image numberSprite;
    Animator animator;
    public GloveCursorScript cursorScript;

    public int counterGoal;

    public RKBehaviourScript behaviourScript;
    public PlayerController playerController;
    public Animator VictoryScreenAnimator;
    public GameObject startButton;
    private AudioSource countdownAudio;
    private AudioReverbFilter reverbFilter;
    public AudioSource musicSource;
    public AudioClip victoryMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        reverbFilter = GetComponent<AudioReverbFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        countdownAudio = GetComponent<AudioSource>();
    }

    public void startCountdown(int goal)
    {
        reverbFilter.enabled = true;
        countdownAudio.time = 0.3f;
        countdownAudio.Play();
        counterGoal = goal;
        counter = 1;
        numberSprite.sprite = numbers[counter - 1];
        animator.SetBool("Countdown", true);
    }

    public void updateCountdown()
    {
        counter++;
        if (counter == counterGoal + 1)
        {
            countdownEnd(false);
            return;
        }
        if (counter <= 10)
        {
            numberSprite.sprite = numbers[counter - 1];
        }
        else
        {
            countdownEnd(true);
        }
    }

    public void countdownEnd(bool win)
    {
        animator.SetBool("Countdown", false);
        if (!win)
        {
            behaviourScript.RKGetUp();
            countdownAudio.Stop();
            reverbFilter.enabled=false;
        } else
        {
            cursorScript.showGlove();
            playerController.playerInCombat = false;
            VictoryScreenAnimator.SetTrigger("Start");
            EventSystem.current.SetSelectedGameObject(startButton);
            musicSource.Stop();
            musicSource.resource = victoryMusic;
            musicSource.Play();
        }
    }
}
