using UnityEngine;

public class MainMenuSoundEffect : MonoBehaviour
{
    public AudioClip[] confirmSounds;
    public AudioClip[] hoverSounds;
    public AudioClip[] openSounds;
    public AudioClip[] closeSounds;

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

    public void playConfirm()
    {
        if(arrayPos >= confirmSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = confirmSounds[arrayPos];
        audioSource.Play();
        arrayPos++;
    }

    public void playHover()
    {
        if (arrayPos >= hoverSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = hoverSounds[arrayPos];
        audioSource.Play();
        arrayPos++;
    }

    public void openSound()
    {
        if (arrayPos >= openSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = openSounds[arrayPos];
        audioSource.Play();
        arrayPos++;
    }

    public void closeSound()
    {
        if (arrayPos >= closeSounds.Length)
        {
            arrayPos = 0;
        }
        audioSource.resource = closeSounds[arrayPos];
        audioSource.Play();
        arrayPos++;
    }
}
