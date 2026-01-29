using UnityEngine;

public class KORecoveryScript : MonoBehaviour
{
    Animator _animator;
    public GameObject Player;
    public GameObject targetPrefab;
    public GameObject LeftSpawn;
    public GameObject RightSpawn;
    public Animator targetSpawnAnimator;

    bool _spawning = false;
    float gapTime = 0.5f;
    float miniGapTime = 0.1f;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void KORecStart()
    {
        _animator.SetBool("KORecOn", true);
        _spawning = true;
        timer = 0;
        targetSpawnAnimator.SetBool("On", true );
    }

    public void HitRight()
    {
        _animator.SetTrigger("RightHit");
    }

    public void HitLeft()
    {
        _animator.SetTrigger("LeftHit");
    }

    public void SpawnLeftTarget()
    {
        Instantiate(targetPrefab, LeftSpawn.transform);
    }

    public void SpawnRightTarget()
    {
        Instantiate(targetPrefab, RightSpawn.transform);
    }
}
