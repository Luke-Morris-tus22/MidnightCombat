using UnityEngine;

public class PlayerCollisionsScript : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collisionCollider;
    public HealthBarScript HealthBarScript;
    public float timeSinceDamageTaken;

    public bool isParrying;
    public TBotAttackScript BotAttackScript;

    void Start()
    {
        _collisionCollider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        timeSinceDamageTaken += Time.deltaTime;
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
                    timeSinceDamageTaken = 0;
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
                    timeSinceDamageTaken = 0;
                }
            }
        }
    }

    public bool playerDodgedCheck()
    {
        //Debug.Log("dodge check");
        if (timeSinceDamageTaken > 2)
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
