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
        public bool playerInRecovery = false;
        public TBotHurtScript botHurtScript;
        public KORecoveryScript KORecoveryScript;
        public HealthBarScript HealthBarScript;


        PlayerInputs _input;
        Animator _animator;
        bool _playerPunchingHead;
        bool _playerPunchingRight;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _input = GetComponent<PlayerInputs>();
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInCombat)
            {
                if (_input.punchRight && !_input.upPressed)
                {
                    _playerPunchingHead = false;
                    _playerPunchingRight = true;
                    _animator.SetTrigger("RSP");
                }

                if (_input.punchRight && _input.upPressed)
                {
                    _playerPunchingHead = true;
                    _playerPunchingRight = true;
                    _animator.SetTrigger("RUP");
                }

                if (_input.punchLeft && !_input.upPressed)
                {
                    _playerPunchingHead = false;
                    _playerPunchingRight = false;
                    _animator.SetTrigger("LSP");
                }

                if (_input.punchLeft && _input.upPressed)
                {
                    _playerPunchingHead = true;
                    _playerPunchingRight = false;
                    _animator.SetTrigger("LUP");
                }

                if (_input.dodgeLeft)
                {
                    _animator.SetTrigger("LeftDodge");
                }

                if (_input.dodgeRight)
                {
                    _animator.SetTrigger("RightDodge");
                }

                if (_input.duck)
                {
                    _animator.SetTrigger("Duck");
                }

                if (_input.parry)
                {
                    _animator.SetTrigger("Parry");
                }

                
            }

            if (playerInRecovery)
            {
                if (_input.punchLeft)
                {
                    KORecoveryScript.HitLeft();
                }
                if (_input.punchRight)
                {
                    KORecoveryScript.HitRight();
                }
            }
        }

        public void PunchHit()
        {
            if (botHurtScript != null)
            {
                botHurtScript.IsHit(_playerPunchingHead, _playerPunchingRight);
            }
        }

        public void clearControls()
        {
            _animator.ResetTrigger("RUP");
            _animator.ResetTrigger("LUP");
            _animator.ResetTrigger("LeftDodge");
            _animator.ResetTrigger("RightDodge");
            _animator.ResetTrigger("RSP");
            _animator.ResetTrigger("LSP");
            _animator.ResetTrigger("Duck");
            _animator.ResetTrigger("Parry");
            _animator.ResetTrigger("HitLeft");
            _animator.ResetTrigger("HitRight");
        }

        public void PlayerHeal(float targetAmount)
        {
            HealthBarScript.Heal(targetAmount);
        }
    }
}
