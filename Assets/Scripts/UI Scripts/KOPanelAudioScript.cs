using UnityEngine;
using UnityEngine.Audio;

public class KOPanelAudioScript : MonoBehaviour
{
    public AudioClip[] heartSounds;

    private AudioSource audioSource;
    public AudioSource droneAudioSource;

    public AudioLowPassFilter musicLowPassFilter;

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

    public void playBeat()
    {
        audioSource.pitch = 1f;
        audioSource.volume = 0.4f;
        if (arrayPos >= heartSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = heartSounds[arrayPos];
        audioSource.PlayOneShot(heartSounds[arrayPos]);
        arrayPos++;
    }

    public void playDrone()
    {
        droneAudioSource.volume = 1;
    }

    public void stopDrone()
    {
        droneAudioSource.volume = 0;
    }

    public void enableMusicBlur()
    {
        musicLowPassFilter.enabled = true;
    }

    public void disableMusicBlur()
    {
        musicLowPassFilter.enabled = false;
    }
}
