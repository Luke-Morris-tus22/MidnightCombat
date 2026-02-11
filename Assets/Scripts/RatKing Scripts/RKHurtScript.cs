using UnityEngine;

public class RKHurtScript : MonoBehaviour
{
    Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isHit(bool hitHead,bool hitRight)
    {
        _animator.SetBool("HitHead", hitHead);
        _animator.SetBool("HitRight", hitRight);
        _animator.SetTrigger("Hit");
    }
}
