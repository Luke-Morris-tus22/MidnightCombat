using UnityEngine;

public class TBotHurtScript : MonoBehaviour
{
    public HealthBarScript healthBarScript;
    public float damageTakeAmount;
    public bool guardUp = false;
    public HurtBoxScript hurtBoxScript;
    public float returnHitCount;
    public float returnHitCountMax;
    public ParticleSystem blockPS;


    Animator _animator;
    TBotAttackScript _attackScript;
    TBotTutorialMasterScript _masterScript;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _attackScript = GetComponent<TBotAttackScript>();
        _masterScript = GetComponent<TBotTutorialMasterScript>();
    }

    void Update()
    {
        _animator.SetBool("GuardUp", guardUp);

    }

    public void IsHit(bool isHead, bool isRight)
    {
        _animator.SetBool("MissedAttack", false);
        _animator.SetBool("HitInHead", isHead);
        _animator.SetBool("HitRight", isRight);
        _animator.SetTrigger("GotHit");
        if (!guardUp)
        {
            returnHitCount += 1;
        }
        if (returnHitCount >= returnHitCountMax)
        {
            _attackScript.RaiseGuard();
            returnHitCount = 0;
        }
    }

    public void takeDamage()
    {
        healthBarScript.TakesDamage(damageTakeAmount);
        if(healthBarScript.Health <= 0)
        {
            _masterScript.robotDefeated();
        }
    }

    public void playBlockPS()
    {
        blockPS.Play();
    }
}
