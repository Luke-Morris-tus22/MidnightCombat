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

    private float _punchHitCooldown;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _attackScript = GetComponent<TBotAttackScript>();
    }

    void Update()
    {
        _punchHitCooldown -= Time.deltaTime;

    }

    public void IsHit(bool isHead, bool isRight)
    {
        if (_punchHitCooldown <= 0)
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
        }
        _punchHitCooldown = 0.4f;


        //Debug.Log("return hit count" + returnHitCount);

    }

    public void takeDamage()
    {
        healthBarScript.TakesDamage(damageTakeAmount);
    }
}
