using StarterAssets;
using UnityEngine;

public class PlayerCollisionsScript : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collisionCollider;
    public HealthBarScript HealthBarScript;
    private float _timeSinceDamageTaken;

    public bool isParrying;
    public TBotAttackScript BotAttackScript;
    public KORecoveryScript KORecoveryScript;

    public bool playerInCombat;

    void Start()
    {
        _collisionCollider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        _timeSinceDamageTaken += Time.deltaTime;
        playerInCombat = GetComponent<PlayerController>().playerInCombat;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            HurtBoxScript hurtBoxScript = other.GetComponent<HurtBoxScript>();
            if (hurtBoxScript.isParriable && isParrying)
            {
                _animator.SetTrigger("ParrySuccess");
                if(BotAttackScript != null)
                {
                    BotAttackScript.attackParried();
                }
            }
            else
            {
                HealthBarScript.TakesDamage(hurtBoxScript.damage);
                if (HealthBarScript.Health <= 0)
                {
                    if (hurtBoxScript.isRight)
                    {
                        _animator.SetTrigger("HitRightKO");

                    }
                    else
                    {
                        _animator.SetTrigger("HitLeftKO");
                    }
                    _timeSinceDamageTaken = 0;
                    KORecoveryScript.KORecStart();
                    GetComponent<PlayerController>().playerInRecovery = true;
                }
                else
                {

                    if (hurtBoxScript.isRight)
                    {
                        _animator.SetTrigger("HitRight");

                    }
                    else
                    {
                        _animator.SetTrigger("HitLeft");
                    }
                    _timeSinceDamageTaken = 0;
                }
            }
        }
    }

    public bool playerDodgedCheck()
    {
        //Debug.Log("dodge check");
        if (_timeSinceDamageTaken > 2)
        {
           // Debug.Log("dodge check true");
            return true;
        }
        else
        {
           // Debug.Log("dodge check false");
            return false;
        }
    }
}
