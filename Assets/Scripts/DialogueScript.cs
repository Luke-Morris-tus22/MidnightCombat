using StarterAssets;
using TMPro;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public bool dialogueOn = false;
    public GameObject player;
    public GameObject dialogueTextGO;
    public string[] dialogueText;
    public int dialogueStringPos;
    private Animator _animator;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerInputs>().punchLeft && dialogueOn)
        {
            continueDialogue();
        }
    }

    public void startDialogue()
    {
        dialogueOn = true;
        _animator.SetBool("DialogueOn", true);
        dialogueStringPos = 0;
        player.GetComponent<PlayerController>().playerInCombat = false;
        dialogueTextGO.GetComponent<TextMeshProUGUI>().text = dialogueText[dialogueStringPos];
    }

    public void continueDialogue()
    {
        dialogueStringPos += 1;
        if (dialogueStringPos >= dialogueText.Length)
        {
            dialogueOn = false;
            _animator.SetBool("DialogueOn", false);
            player.GetComponent<PlayerController>().playerInCombat = true;
        } else
        {
            dialogueTextGO.GetComponent<TextMeshProUGUI>().text = dialogueText[dialogueStringPos];
        }

    }
}
