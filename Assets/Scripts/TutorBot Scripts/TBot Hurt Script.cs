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
    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void IsHit(bool isHead, bool isRight)
    {
        _animator.SetBool("MissedAttack", false);
        _animator.SetBool("GuardUp", guardUp);
        _animator.SetBool("HitInHead", isHead);
        _animator.SetBool("HitRight", isRight);
        _animator.SetTrigger("GotHit");
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
