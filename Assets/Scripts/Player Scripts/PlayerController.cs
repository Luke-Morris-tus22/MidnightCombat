using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
#if ENABLE_INPUT_SYSTEM
    [RequireComponent(typeof(PlayerInput))]
#endif
    public class PlayerController : MonoBehaviour
    {
        public bool inTutorial;

        public bool playerInCombat = true;
        public PlayerInputs _input;
        public Animator animator;

        public bool playerPunchingHead;
        public bool playerPunchingRight;

        public TBotHurtScript botHurtScript;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _input = GetComponent<PlayerInputs>();
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInCombat)
            {
                if (_input.punchRight && !_input.upPressed)
                {
                    playerPunchingHead = false;
                    playerPunchingRight = true;
                    animator.SetTrigger("RSP");
                }

                if (_input.punchRight && _input.upPressed)
                {
                    playerPunchingHead = true;
                    playerPunchingRight = true;
                    animator.SetTrigger("RUP");
                }

                if (_input.punchLeft && !_input.upPressed)
                {
                    playerPunchingHead = false;
                    playerPunchingRight = false;
                    animator.SetTrigger("LSP");
                }

                if (_input.punchLeft && _input.upPressed)
                {
                    playerPunchingHead = true;
                    playerPunchingRight = false;
                    animator.SetTrigger("LUP");
                }

                if (_input.dodgeLeft)
                {
                    animator.SetTrigger("LeftDodge");
                }

                if (_input.dodgeRight)
                {
                    animator.SetTrigger("RightDodge");
                }

                if (_input.duck)
                {
                    animator.SetTrigger("Duck");
                }

                if (_input.parry)
                {
                    animator.SetTrigger("Parry");
                }
            }
        }

        public void PunchHit()
        {
            if (botHurtScript != null)
            {
                botHurtScript.IsHit(playerPunchingHead, playerPunchingRight);
            }
        }

        public void clearControls()
        {
            animator.ResetTrigger("RUP");
            animator.ResetTrigger("LUP");
            animator.ResetTrigger("LeftDodge");
            animator.ResetTrigger("RightDodge");
            animator.ResetTrigger("RSP");
            animator.ResetTrigger("LSP");
            animator.ResetTrigger("Duck");
            animator.ResetTrigger("Parry");
            animator.ResetTrigger("HitLeft");
            animator.ResetTrigger("HitRight");
        }
    }
}
