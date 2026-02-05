using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class KORecoveryScript : MonoBehaviour
{
    Animator _animator;
    public GameObject Player;
    public GameObject targetPrefab;
    public GameObject LeftSpawn;
    public GameObject RightSpawn;
    public Animator targetSpawnAnimator;
    public Animator resultAnimator;

    public float recoveryScore;
    public float scoreGood = 10;
    public float scoreBad = -10;
    public float scorePerfect = 30;

    public bool recoveryActive;

    public Slider slider;

    public TBotTutorialMasterScript botTutorialMasterScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = recoveryScore;
        Player.GetComponent<Animator>().SetFloat("RecoveryScore", recoveryScore);
    }

    public void KORecStart()
    {
        recoveryActive = true;
        _animator.SetBool("KORecOn", true);
        targetSpawnAnimator.SetBool("On", true );
        recoveryScore = 30;
        Player.GetComponent<PlayerController>().playerInCombat = false;
        Player.GetComponent<PlayerController>().playerInRecovery = true;

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

    public void ScoreGood()
    {
        resultAnimator.SetTrigger("Good");
        recoveryScore += scoreGood;
        if (recoveryScore >= 100)
        {
            RecoverSuccess();
        }
    }
    public void ScoreBad()
    {
        resultAnimator.SetTrigger("Bad");
        recoveryScore += scoreBad;
    }
    public void ScorePerfect()
    {
        resultAnimator.SetTrigger("Perfect");
        recoveryScore += scorePerfect;
        if (recoveryScore >= 100)
        {
            RecoverSuccess();
        }
    }

    public void RecoverSuccess()
    {
        recoveryActive = false;
        _animator.SetBool("KORecOn", false);
        targetSpawnAnimator.SetBool("On", false);
        Player.GetComponent<PlayerController>().playerInCombat = true;
        Player.GetComponent<PlayerController>().playerInRecovery = false;

        Player.GetComponent<PlayerController>().PlayerHeal(100);

        if (botTutorialMasterScript != null)
        {
            botTutorialMasterScript.StartPhaseRecoverDone();
        }
    }
    public void RecoverFail()
    {
        recoveryActive = false;

    }
}
