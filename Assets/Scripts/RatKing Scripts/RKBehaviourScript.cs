using UnityEngine;

public class RKBehaviourScript : MonoBehaviour
{
    private float phase;
    public string[] SparAttackOrder;
    private int sparAttackPos;
    private RKAttackScript _attackScript;
    private RKHurtScript _hurtScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phase = 1;
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
    }
