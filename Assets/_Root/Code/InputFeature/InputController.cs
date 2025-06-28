using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Game.Code.InputFeature
{



    public class InputController
    {
        private PlayerInput _playerInput;
        public event Action OnSubmit = delegate { };
        public event Action OnBack = delegate { };
        public event Action<Vector2> OnNavigateButtonsClick = delegate { };
        
        public InputController(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            _playerInput.actions.Enable();
            _playerInput.actions.FindActionMap("Navigate").FindAction("Submit").performed += OnSubmitPerfomed;
            _playerInput.actions.FindActionMap("Navigate").FindAction("Back").performed += OnBackPerfomed;
            _playerInput.actions.FindActionMap("Navigate").FindAction("NavigateBetwenMenuButtons").performed +=
                OnNavigateClicked;

        }

        private void OnNavigateClicked(InputAction.CallbackContext obj)
        {
            OnNavigateButtonsClick?.Invoke(obj.ReadValue<Vector2>());
        }

        private void OnBackPerfomed(InputAction.CallbackContext obj)
        {
            OnBack();
        }

        private void OnSubmitPerfomed(InputAction.CallbackContext obj)
        {
            OnSubmit();
        }
    }
}