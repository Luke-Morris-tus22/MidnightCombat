using System.Xml.Serialization;
using UnityEngine;

public class TBotAttackScript : MonoBehaviour
{
    private Animator _animator;
    public float attackInterval = 2; //seconds before starting an attack
    private float _attackIntervalCounter;
    private TBotHurtScript _botHurtScript;
    public PlayerCollisionsScript playerCollisionsScript;
    public HurtBoxScript hurtBoxScript;

    public bool guardDownOverwrite;
    public bool attackingActive;
    public string currentAttack;

    private TBotTutorialMasterScript _botTutorialMasterScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _botHurtScript = GetComponent<TBotHurtScript>();
        _botTutorialMasterScript = GetComponent<TBotTutorialMasterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _attackIntervalCounter += Time.deltaTime;
        if (_attackIntervalCounter > attackInterval && playerCollisionsScript.playerInCombat && attackingActive)
        {
            Attack();
        }
        if (!playerCollisionsScript.playerInCombat)
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
        _animator.SetBool("MissedAttack", playerCollisionsScript.playerDodgedCheck());
        _botHurtScript.returnHitCountMax = hurtBoxScript.returnHitsCount;

    }

    public void LowerGuard()
    {
        _botHurtScript.guardUp = false;
    }

    public void RaiseGuard()
    {
        if (!guardDownOverwrite)
        {
            _botHurtScript.guardUp = true;
            _botHurtScript.returnHitCount = 0;
        } else
        {
            _botHurtScript.guardUp = false;
        }
    }

    public void attackParried()
    {
        _animator.SetBool("MissedAttack", true);
        _botHurtScript.returnHitCountMax = hurtBoxScript.parryReturnHitsCount;
        _botTutorialMasterScript.beenParried();
    }
}
