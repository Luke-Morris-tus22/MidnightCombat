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

#if ENABLE_INPUT_SYSTEM

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
#endif
        public void LateUpdate()
        {
            punchRight = false;
            punchLeft = false;
        }
    }
}