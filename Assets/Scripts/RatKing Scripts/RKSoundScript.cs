using UnityEngine;

public class RKSoundScript : MonoBehaviour
{
    public AudioClip[] windUpSounds;
    public AudioClip[] punchSounds;
    public AudioClip[] gotHitSounds;
    public AudioClip[] knockedDownSounds;
    public AudioClip[] parrySounds;
    public AudioClip[] shockSounds;

    private AudioSource audioSource;

    private int arrayPos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playWindUp()
    {
        if (arrayPos >= windUpSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.PlayOneShot(windUpSounds[arrayPos]);
        arrayPos++;
    }

    public void playPunch()
    {
        if (arrayPos >= punchSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.PlayOneShot(punchSounds[arrayPos]);
        arrayPos++;
    }

    public void playGotHit()
    {
        if (arrayPos >= gotHitSounds.Length)
        {
            arrayPos = 0;
        }
        if (gotHitSounds[arrayPos] != null)
        {
            audioSource.PlayOneShot(gotHitSounds[arrayPos]);
        }
        arrayPos++;
    }

    public void playKO()
    {
        if (arrayPos >= knockedDownSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.PlayOneShot(knockedDownSounds[arrayPos]);
        arrayPos++;
    }

    public void playParry()
    {
        if (arrayPos >= parrySounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.PlayOneShot(parrySounds[arrayPos]);
        arrayPos++;
    }

    public void playShock()
    {
        if (arrayPos >= shockSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.PlayOneShot(shockSounds[arrayPos]);
        arrayPos++;
    }
}
