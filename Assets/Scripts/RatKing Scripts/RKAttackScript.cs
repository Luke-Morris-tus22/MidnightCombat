using UnityEngine;

public class RKAttackScript : MonoBehaviour
{
    Animator _animator;
    public float attackInterval;
    private float _attackIntervalCounter;
    private RKHurtScript _hurtScript;
    public PlayerCollisionsScript playerCollisionScript;
    public HurtBoxScript HurtBoxScript;

    public bool attackingActive;
    public string currentAttack;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _hurtScript = GetComponent<RKHurtScript>();
        currentAttack = "LeftJab";
    }

    void Update()
    {
        _attackIntervalCounter += Time.deltaTime;
        if (_attackIntervalCounter > attackInterval && playerCollisionScript.playerInCombat && attackingActive)
        {
            Attack();
        }
        if (!playerCollisionScript.playerInCombat)
        {
            restartAttackCounter();
        }
    }

    public void restartAttackCounter()
    {
        _attackIntervalCounter = 0;
    }

    public void Attack()
    {
        _animator.SetTrigger(currentAttack);
        _attackIntervalCounter = 0;
    }

    public void attackSuccessCheck()
    {
        //Debug.Log("attack success check");
        _animator.SetBool("AttackMissed", playerCollisionScript.playerDodgedCheck());
        _hurtScript.returnHitCountMax = HurtBoxScript.returnHitsCount;

    }
}
