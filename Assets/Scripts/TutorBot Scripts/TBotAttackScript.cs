using System.Xml.Serialization;
using UnityEngine;

public class TBotAttackScript : MonoBehaviour
{
    private Animator _animator;
    public float attackInterval = 5; //seconds before starting an attack
    private float _attackIntervalCounter;
    private TBotHurtScript _botHurtScript;
    public PlayerCollisionsScript playerCollisionsScript;
    public HurtBoxScript hurtBoxScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _botHurtScript = GetComponent<TBotHurtScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _attackIntervalCounter += Time.deltaTime;
        if (_attackIntervalCounter > attackInterval)
        {
            Attack();
        }
        //Debug.Log(_attackIntervalCounter);
        
    }

    public void restartAttackCounter()
    {
        _attackIntervalCounter = 0;
    }

    public void Attack()
    {
        _animator.SetTrigger("StartJab");
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
        Debug.Log("Lower Guard");
        _botHurtScript.guardUp = false;
    }

    public void RaiseGuard()
    {
        _botHurtScript.guardUp = true;
        _botHurtScript.returnHitCount = 0;
    }

}
