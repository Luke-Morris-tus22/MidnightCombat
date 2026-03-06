using UnityEngine;

public class RKBehaviourScript : MonoBehaviour
{
    private float phase;
    private float KOCounter;
    public string[] SparAttackOrder;
    private int sparAttackPos;
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

        sparAttackPos += 1;
        if (sparAttackPos >= SparAttackOrder.Length)
        {
            sparAttackPos = 0;
        }
        _attackScript.currentAttack = SparAttackOrder[sparAttackPos];
    }

    public void KnockDown()
    {
        CDScript.startCountdown(4);
    }

    public void RKGetUp()
    {
        animator.SetBool("KnockedOut", false);
        RKHealthbarScript.Heal(100);
    }
}


