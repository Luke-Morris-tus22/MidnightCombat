using StarterAssets;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    public Animator CombatUIMaskAnimator;
    public PlayerController controller;
    public RKAttackScript attackScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
