using UnityEngine;

public class RKBehaviourScript : MonoBehaviour
{
    private float phase;
    private float KOCounter;
    public string[] PhaseOneAttackOrder;
    public string[] PhaseTwoAttackOrder;
    public string[] PhaseThreeAttackOrder;
    private int AttackPos;
    private RKAttackScript _attackScript;
    private RKHurtScript _hurtScript;
    public CountdownScript CDScript;
    public HealthBarScript RKHealthbarScript;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phase = 1;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _attackScript = GetComponent<RKAttackScript>();
        _hurtScript = GetComponent<RKHurtScript>();
    }

    public void PrepareNextAttack()
    {

        AttackPos += 1;
        if (AttackPos >= PhaseOneAttackOrder.Length)
        {
            AttackPos = 0;
        }
        if (phase == 1)
        {
            _attackScript.currentAttack = PhaseOneAttackOrder[AttackPos];
        }
        else if (phase == 2)
        {
            _attackScript.currentAttack = PhaseTwoAttackOrder[AttackPos];
        }
        else if (phase == 3)
        {
            _attackScript.currentAttack = PhaseThreeAttackOrder[AttackPos];
        }
    }

    public void KnockDown()
    {
        int time;
        if (phase == 1)
        {
            time = 4;
        }
        else if (phase == 2)
        {
            time = 8;
        }
        else
        {
            time = 11;
        }
        CDScript.startCountdown(time);
    }

    public void RKGetUp()
    {
        animator.SetBool("KnockedOut", false);
        RKHealthbarScript.Heal(100);
        phase++;
        AttackPos = 0;
    }
}


