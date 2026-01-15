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
        public bool playerInCombat = true;
        public PlayerInputs _input;
        public Animator animator;

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
                    animator.SetTrigger("RSP");
                }

                if (_input.punchRight && _input.upPressed)
                {
                    animator.SetTrigger("RUP");
                }

                if (_input.punchLeft && !_input.upPressed)
                {
                    animator.SetTrigger("LSP");
                }

                if (_input.punchLeft && _input.upPressed)
                {
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
    }
}
