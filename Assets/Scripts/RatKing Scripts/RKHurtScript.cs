using UnityEngine;

public class RKHurtScript : MonoBehaviour
{
    public HealthBarScript healthBarScript;
    public float damageTakeAmount;
    public bool guardUp = true;
    public bool invulnerable;
    public HurtBoxScript hurtBoxScript;
    public float returnHitCount;
    public float returnHitCountMax;
    public ParticleSystem blockPS;

    Animator _animator;
    RKAttackScript _attackScript;
    RKBehaviourScript _behaviourScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _attackScript = GetComponent<RKAttackScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("GuardUp", guardUp);
    }

    public void isHit(bool hitHead, bool hitRight)
    {
        if (!invulnerable)
        {
            returnHitCount += 1;

            _animator.SetBool("HitHead", hitHead);
            _animator.SetBool("HitRight", hitRight);
            _animator.SetTrigger("Hit");
            if (returnHitCount == returnHitCountMax)
            {
                _animator.SetBool("Stunned", false);
                _animator.SetBool("StunEnd", true);
            }

        }
    }

    public void takeDamage()
    {
        _animator.SetBool("Stunned", true);

        healthBarScript.TakesDamage(damageTakeAmount);
        if (healthBarScript.Health <= 0)
        {
            // _masterScript.robotDefeated();
           // _behaviourScript.KnockDown();
            _animator.SetBool("KnockedOut", true);

        }
    }

    public void playBlockPS()
    {
        blockPS.Play();
    }

    public void LowerGuard()
    {
        if (guardUp)
        {
            guardUp = false;
        }
        _animator.SetBool("StunEnd", false);
        returnHitCount = 0;

    }

    public void RaiseGuard()
    {
        _animator.SetBool("Stunned", false);
        if (!guardUp)
        {
            guardUp = true;
        }
    }
}
