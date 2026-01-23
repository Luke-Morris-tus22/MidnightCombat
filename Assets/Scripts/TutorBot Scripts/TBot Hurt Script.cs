using UnityEngine;

public class TBotHurtScript : MonoBehaviour
{
    public HealthBarScript healthBarScript;
    public float health;
    public float maxHealth;
    public float damageTakeAmount;

    public bool guardUp = false;
    public HurtBoxScript hurtBoxScript;
    public float returnHitCount;
    public float returnHitCountMax;
    Animator animator_;

    void Start()
    {
        animator_ = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void IsHit(bool isHead, bool isRight)
    {
        animator_.SetBool("GuardUp", guardUp);
        animator_.SetBool("HitInHead", isHead);
        animator_.SetBool("HitRight", isRight);
        animator_.SetTrigger("GotHit");
        returnHitCount += 1;
        if (returnHitCount >= returnHitCountMax) 
        {
            guardUp = true;
            returnHitCount = 0;
        }

        Debug.Log("return hit count" + returnHitCount);

    }

    public void takeDamage()
    {
        healthBarScript.TakesDamage(damageTakeAmount);
    }
}
