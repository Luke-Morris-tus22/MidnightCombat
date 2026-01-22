using UnityEngine;

public class PlayerCollisionsScript : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collisionCollider;
    public HealthBarScript HealthBarScript;
    public float timeSinceDamageTaken;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collisionCollider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDamageTaken += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      //  Debug.Log("Trigger");
        if (other.CompareTag("EnemyAttack"))
        {
            HurtBoxScript hurtBoxScript = other.GetComponent<HurtBoxScript>();
            if (hurtBoxScript.isRight)
            {
                _animator.SetTrigger("HitRight");

            }
            else
            {
                _animator.SetTrigger("HitLeft");
            }
            HealthBarScript.TakesDamage(hurtBoxScript.damage);
            timeSinceDamageTaken = 0;
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
