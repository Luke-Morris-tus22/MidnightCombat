using UnityEngine;

public class PlayerCollisionsScript : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collisionCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collisionCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator = GetComponent<Animator>();   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      //  Debug.Log("Trigger");
        if (other.CompareTag("EnemyAttack"))
        {
            Debug.Log("Player Hit");
            _animator.SetTrigger("HitRight");
        }
    }
}
