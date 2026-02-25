using UnityEngine;

public class RKHurtScript : MonoBehaviour
{
    public HealthBarScript healthBarScript;
    public float damageTakeAmount;
    public bool guardUp = false;
    public bool invulnerable;
    public HurtBoxScript hurtBoxScript;
    public float returnHitCount;
    public float returnHitCountMax;
    public ParticleSystem blockPS;

    Animator _animator;
    RKAttackScript _attackScript;

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

    public void isHit(bool hitHead,bool hitRight)
    {
        if (!invulnerable)
        {
            _animator.SetBool("HitHead", hitHead);
            _animator.SetBool("HitRight", hitRight);
            _animator.SetTrigger("Hit");
            if (returnHitCount >= returnHitCountMax)
            {
                guardUp = true;
                returnHitCount = 0;
            }
        }
    }

    public void takeDamage()
    {
        returnHitCount += 1;
        healthBarScript.TakesDamage(damageTakeAmount);
        if (healthBarScript.Health <= 0)
        {
           // _masterScript.robotDefeated();
        }
    }

    public void playBlockPS()
    {
        blockPS.Play();
    }
}
