using System.Xml.Serialization;
using UnityEngine;

public class TBotAttackScript : MonoBehaviour
{
    private Animator _animator;
    public float attackInterval = 3; //seconds before starting an attack
    private float _attackIntervalCounter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _attackIntervalCounter += Time.deltaTime;
        if (_attackIntervalCounter > attackInterval)
        {
            Attack();
        }
    }

    public void restartAttackCounter()
    {
        _attackIntervalCounter = 0;
    }

    public void Attack()
    {
        _animator.SetTrigger("StartJab");
    }
}
