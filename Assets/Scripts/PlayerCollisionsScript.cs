using UnityEngine;

public class PlayerCollisionsScript : MonoBehaviour
{
    private Collider2D _collisionCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collisionCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      //  Debug.Log("Trigger");
        if (other.CompareTag("EnemyAttack"))
        {
           // Debug.Log("Player Hit");
        }
    }
}
