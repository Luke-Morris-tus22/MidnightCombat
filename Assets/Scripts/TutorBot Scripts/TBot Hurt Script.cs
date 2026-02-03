using UnityEngine;

public class TBotHurtScript : MonoBehaviour
{
    public HealthBarScript healthBarScript;
    public float damageTakeAmount;

    public bool guardUp = false;
    public HurtBoxScript hurtBoxScript;
    public float returnHitCount;
    public float returnHitCountMax;
    Animator _animator;
    TBotAttackScript _attackScript;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _attackScript = GetComponent<TBotAttackScript>();
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
            _attackScript.RaiseGuard();
            returnHitCount = 0;
        }

        //Debug.Log("return hit count" + returnHitCount);

    }

    public void takeDamage()
    {
        healthBarScript.TakesDamage(damageTakeAmount);
    }
}
