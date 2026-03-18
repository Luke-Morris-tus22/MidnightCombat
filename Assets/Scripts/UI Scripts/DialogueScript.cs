using StarterAssets;
using TMPro;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public bool dialogueOn = false;
    public GameObject player;
    public GameObject dialogueTextGO;
    public Animator animator;


    public string[] dialogueTextIntro;
    public string[] dialogueTextPunchUp;
    public string[] dialogueTextDodge;
    public string[] dialogueTextDuck;
    public string[] dialogueTextParry;
    public string[] dialogueTextSpar;
    public string[] dialogueTextSparWin1;
    public string[] dialogueTextSparWin2;
    public string[] dialogueTextSparLose;

    public string[] dialogueTextCurrent;

    private int _dialogueStringPos;

    private float _continueBlockTimer = 0.3f; //Amount of time in seconds that the player has to wait before they can continue dialogue
    public bool dialogueEnded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.GetComponent<PlayerInputs>().punchLeft || player.GetComponent<PlayerInputs>().parry) && dialogueOn && _continueBlockTimer <=0)
        {
            continueDialogue();
            _continueBlockTimer = 0.5f;
        }
        if (_continueBlockTimer > 0)
        {
            _continueBlockTimer -= Time.deltaTime;
        }
    }

    public void startDialogue()
    {
        dialogueOn = true;
        animator.SetBool("DialogueOn", true);
        _dialogueStringPos = 0;
        player.GetComponent<PlayerController>().playerInCombat = false;
        dialogueTextGO.GetComponent<TextMeshProUGUI>().text = dialogueTextCurrent[_dialogueStringPos];
        _continueBlockTimer = 0.75f;
    }

    public void continueDialogue()
    {
        _dialogueStringPos += 1;
        if (_dialogueStringPos >= dialogueTextCurrent.Length)
        {
            endDialogue();
        } else
        {
            dialogueTextGO.GetComponent<TextMeshProUGUI>().text = dialogueTextCurrent[_dialogueStringPos];
        }

    }

    public void endDialogue()
    {
        dialogueOn = false;
        animator.SetBool("DialogueOn", false);
        player.GetComponent<PlayerController>().playerInCombat = true;
        dialogueEnded = true;
    }
}
