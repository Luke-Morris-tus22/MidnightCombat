using UnityEngine;

public class EnemyhitBox : MonoBehaviour
{
    public Animator animator;
    public GameObject hitbox;
    public float repeatPunchTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitbox.transform.position = new Vector3(0,12,0);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       repeatPunchTime += Time.deltaTime;
        if (repeatPunchTime > 5)
        {
            animator.SetTrigger("EnemyAttack");
            repeatPunchTime = 0;
        }
    }

    public void MoveHitbox()
    {
        hitbox.transform.position = Vector3.zero;
    }

    public void resetHitbox()
    {
        hitbox.transform.position = new Vector3(0, 12, 0);
    }
}
