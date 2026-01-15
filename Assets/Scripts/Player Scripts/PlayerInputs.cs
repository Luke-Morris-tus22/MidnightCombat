using JetBrains.Annotations;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class PlayerInputs : MonoBehaviour
    {
        [Header("Character Input Values")]

        public bool punchRight;
        public bool punchLeft;
        public bool dodgeRight;
        public bool dodgeLeft;
        public bool upPressed;
        public bool duck;
        public bool parry;

#if ENABLE_INPUT_SYSTEM

        public void OnUpHeld(InputValue value)
        {
            if (value.isPressed)
            {
                upPressed = true;
            } else
            {
                upPressed = false;
            }
        }

        public void OnRightAttack(InputValue value)
        {
            if (value.isPressed)
            {
                punchRight = true;
            }
        }

        public void OnLeftAttack(InputValue value)
        {
            if (value.isPressed)
            {
                punchLeft = true;
            }
        }

        public void OnLeftDodge(InputValue value)
        {
            if (value.isPressed)
            {
                dodgeLeft = true;
            }
        }

        public void OnRightDodge(InputValue value)
        {
            if (value.isPressed)
            {
                dodgeRight = true;
            }
        }

        public void OnDuck(InputValue value)
        {
            if (value.isPressed)
            {
                duck = true;
            }
        }

        public void OnParry(InputValue value)
        {
            if (value.isPressed)
            {
                parry = true;
            }
        }
#endif
        public void LateUpdate()
        {
            punchRight = false;
            punchLeft = false;
            dodgeLeft=false;
            dodgeRight=false;
            duck = false;
            parry = false;
        }
    }
}