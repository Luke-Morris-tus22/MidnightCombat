using TMPro;
using UnityEngine;

public class TBotTutorialMasterScript : MonoBehaviour
{
    private float _tutorialPhase;

    public TextMeshProUGUI ObjectiveText;
    public TextMeshProUGUI ObjectiveCounterText;
    public DialogueScript DialogueScript;
    public HurtBoxScript HurtBoxScript;
    private TBotAttackScript _attackScript;
    private TBotHurtScript _hurtScript;

    private bool _inDialogue;
    private float _tutorialObjectGoal;
    private float _tutorialObjectiveProgress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _tutorialPhase = 0;
        DialogueScript.dialogueTextCurrent = DialogueScript.dialogueTextIntro;
        DialogueScript.startDialogue();
        _inDialogue = true;
        _attackScript = GetComponent<TBotAttackScript>();
        _hurtScript = GetComponent<TBotHurtScript>();
        HurtBoxScript.damage = 0;
        _hurtScript.damageTakeAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectiveCounterText.text = "(" + _tutorialObjectiveProgress + "/" + _tutorialObjectGoal + ")";
        if (DialogueScript.dialogueEnded)
        {
            if (_tutorialPhase == 0)
            {
                StartPhase1();
            }
            else if (_tutorialPhase == 1)
            {
                StartPhase2();
            } else if (_tutorialPhase == 2)
            {
                StartPhase3();
            } else if (_tutorialPhase == 3)
            {
                StartPhase4();
            } else if (_tutorialPhase == 4)
            {
                StartPhase5();
            }
                DialogueScript.dialogueEnded = false;
            _inDialogue = false;
        }
    }

    public void StartPhase1()
    {
        _tutorialPhase = 1;
        ObjectiveText.text = "Punch the robot four times";
        _tutorialObjectGoal = 4;
        _tutorialObjectiveProgress = 0;
        _attackScript.guardDownOverwrite = true;
        _attackScript.attackingActive = false;
    }

    public void beenPunched()
    {
        if (_tutorialPhase == 1)
        {
            _tutorialObjectiveProgress += 1;
            if(_tutorialObjectiveProgress == _tutorialObjectGoal)
            {
                DialogueScript.dialogueTextCurrent = DialogueScript.dialogueTextPunchUp;
                DialogueScript.startDialogue();
            }
        }
    }

    public void StartPhase2()
    {
        _tutorialPhase = 2;
        ObjectiveText.text = "Punch the robot in the head four times";
        _tutorialObjectGoal = 4;
        _tutorialObjectiveProgress = 0;
        _attackScript.guardDownOverwrite = true;
        _attackScript.attackInterval = 2;
    }

    public void beenPunchedHead()
    {
        if (_tutorialPhase == 2)
        {
            _tutorialObjectiveProgress += 1;
            if (_tutorialObjectiveProgress == _tutorialObjectGoal)
            {
                DialogueScript.dialogueTextCurrent = DialogueScript.dialogueTextDodge;
                DialogueScript.startDialogue();
            }
        }
    }

    public void StartPhase3()
    {
        _tutorialPhase = 3;
        ObjectiveText.text = "Dodge the robot's attacks 3 times";
        _tutorialObjectGoal = 3;
        _tutorialObjectiveProgress = 0;
        _attackScript.guardDownOverwrite = false;
        _attackScript.attackingActive = true;
        _attackScript.currentAttack = "StartJab";
    }

    public void beenDodged()
    {
        if (_tutorialPhase == 3)
        {
            _tutorialObjectiveProgress += 1;
            if (_tutorialObjectiveProgress == _tutorialObjectGoal)
            {
                DialogueScript.dialogueTextCurrent = DialogueScript.dialogueTextDuck;
                DialogueScript.startDialogue();
            }
        }
    }

    public void StartPhase4()
    {
        _tutorialPhase = 4;
        ObjectiveText.text = "Duck under the robot's attacks 3 times";
        _tutorialObjectGoal = 3;
        _tutorialObjectiveProgress = 0;
        _attackScript.guardDownOverwrite = false;
        _attackScript.attackingActive = true;
        _attackScript.currentAttack = "StartHook";
    }

    public void beenDucked()
    {
        if (_tutorialPhase == 4)
        {
            _tutorialObjectiveProgress += 1;
            if (_tutorialObjectiveProgress == _tutorialObjectGoal)
            {
                DialogueScript.dialogueTextCurrent = DialogueScript.dialogueTextParry;
                DialogueScript.startDialogue();
            }
        }
    }
    public void StartPhase5()
    {
        _tutorialPhase = 5;
        ObjectiveText.text = "Parry the robot's attacks 3 times";
        _tutorialObjectGoal = 3;
        _tutorialObjectiveProgress = 0;
        _attackScript.guardDownOverwrite = false;
        _attackScript.attackingActive = true;
        _attackScript.currentAttack = "StartJabP";
    }

    public void beenParried()
    {
        if (_tutorialPhase == 5)
        {
            _tutorialObjectiveProgress += 1;
            if (_tutorialObjectiveProgress == _tutorialObjectGoal)
            {
                DialogueScript.dialogueTextCurrent = DialogueScript.dialogueTextSpar;
                DialogueScript.startDialogue();
            }
        }
    }

    public void StartPhaseSpar()
    {
        _tutorialPhase = 6;
        ObjectiveText.enabled = false;
        ObjectiveCounterText.enabled = false;
        _attackScript.guardDownOverwrite = false;
        _attackScript.attackingActive = true;
        _attackScript.currentAttack = "StartJab";
    }
}
