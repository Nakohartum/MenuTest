using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

namespace Game.Code.ScreenFeature
{
    public class UIInputManager
    {
        private PlayerInput _playerInput;
        public InputUIContext Context { get; private set; }

        public UIInputManager(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            Context = new InputUIContext();
            _playerInput.onControlsChanged += _ => ApplyCurrentStrategy();
            _playerInput.actions.FindActionMap("Navigate").Enable(); 
        }

        public void ApplyCurrentStrategy()
        {
            string scheme = _playerInput.currentControlScheme;
            if (scheme == "PC")
            {
                Context.SetStrategy(new PCStrategy());
            }
            else if (scheme == "ConsoleInput")
            {
                var g = Gamepad.current;
                if (g != null)
                {
                    if (g.name.Contains("DualSense") || g.name.Contains("DualShock"))
                    {
                        Context.SetStrategy(new PSStrategy());
                    }
                    else
                    {
                        Context.SetStrategy(new XboxStrategy());
                    }
                }
            }
        }
    }
}