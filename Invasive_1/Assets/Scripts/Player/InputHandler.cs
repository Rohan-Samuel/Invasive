using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNS
{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        public bool b_Input;

        public bool crouchFlag;
        public bool crouchHoldFlag;
        public float crouchInputTimer;
        public bool isInteracting;

        PlayerControls inputActions;
        CameraHandler cameraHandler;

        Vector2 movementInput;
        Vector2 cameraInput;

        private void Awake()
        {
            cameraHandler = CameraHandler.singleton;
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;

            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, mouseX, mouseY);
            }

            if (b_Input)
            {
                Debug.Log("cmon man");
            }
            
        }

        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();

        }

        public void TickInput (float delta)
        {
            MoveInput(delta);
            HandleCrouchInput(delta);
        }

        private void MoveInput (float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleCrouchInput(float delta)
        {
            b_Input = inputActions.PlayerActions.Crouch.phase == UnityEngine.InputSystem.InputActionPhase.Performed;
            

            if (b_Input)
            {
                crouchInputTimer += delta;
                crouchHoldFlag = true;
            }
            else
            {
                if(crouchInputTimer > 0 && crouchInputTimer < 0.5f)
                {
                    crouchHoldFlag = false;
                    crouchFlag = true;
                }
                crouchInputTimer = 0;
            }
            
        }
    }
}