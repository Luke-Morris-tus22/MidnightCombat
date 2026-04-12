using UnityEngine;
using UnityEngine.Audio;

public class playerAudioScript : MonoBehaviour
{
    public AudioClip[] dodgeSounds;
    public AudioClip[] gotHitSounds;
    public AudioClip[] parrySounds;
    public AudioClip[] punchSounds;
    public AudioClip[] KOSounds;

    private AudioSource audioSource;

    private int arrayPos = 0;

    private float audioVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioVolume = audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playDodge()
    {
        audioSource.pitch = 1f;
        audioSource.volume = 0.4f * audioVolume;
        if (arrayPos >= dodgeSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = dodgeSounds[arrayPos];
        audioSource.PlayOneShot(dodgeSounds[arrayPos]);
        arrayPos++;
    }

    public void playHit()
    {
        audioSource.pitch = 1.25f;
        audioSource.volume = audioVolume;

        if (arrayPos >= gotHitSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = gotHitSounds[arrayPos];
        audioSource.PlayOneShot(gotHitSounds[arrayPos]);
        arrayPos++;
    }

    public void playParry()
    {
        audioSource.volume = audioVolume;

        if (arrayPos >= parrySounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = parrySounds[arrayPos];
        audioSource.PlayOneShot(parrySounds[arrayPos]);
        arrayPos++;
    }

    public void playPunch()
    {
        audioSource.volume = audioVolume;

        audioSource.pitch = 1f;
        if (arrayPos >= punchSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = punchSounds[arrayPos];
        audioSource.PlayOneShot(punchSounds[arrayPos]);
        arrayPos++;
    }

    public void playKO()
    {
        audioSource.volume = audioVolume;

        audioSource.pitch = 1f;
        if (arrayPos >= KOSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = KOSounds[arrayPos];
        audioSource.PlayOneShot(KOSounds[arrayPos]);
        arrayPos++;
    }
}
