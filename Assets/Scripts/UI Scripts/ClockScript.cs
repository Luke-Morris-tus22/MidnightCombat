using StarterAssets;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    public Animator CombatUIMaskAnimator;
    public PlayerController controller;
    public RKAttackScript attackScript;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startCountdown()
    {
        controller.playerInCombat = false;
        attackScript.attackingActive = false;
    }

    public void stopCountdown()
    {
        CombatUIMaskAnimator.SetTrigger("Start");
        controller.playerInCombat = true;
        attackScript.attackingActive = true;
    }

    public void playAudio()
    {
        audioSource.Play();
    }
}
