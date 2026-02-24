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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _hurtScript = GetComponent<RKHurtScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
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
        _animator.SetBool("MissedAttack", playerCollisionScript.playerDodgedCheck());
       // RKHurtScript.returnHitCountMax = hurtBoxScript.returnHitsCount;

    }
}
