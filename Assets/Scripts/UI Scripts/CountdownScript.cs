using StarterAssets;
using UnityEngine;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startCountdown(int goal)
    {
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
        } else
        {
            cursorScript.showGlove();
            playerController.playerInCombat = false;
            VictoryScreenAnimator.SetTrigger("Start");

        }
    }
}
