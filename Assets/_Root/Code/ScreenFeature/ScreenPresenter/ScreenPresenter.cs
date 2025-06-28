using System;
using System.Collections.Generic;
using Game.Code.InputFeature;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Code.ScreenFeature.ScreenPresenter
{
    public class ScreenPresenter
    {
        private InputController _inputController;
        private Dictionary<Type, IScreenPresenter> _views = new();
        private IScreenPresenter _currentScreenPresenter;

        public ScreenPresenter(InputController inputController)
        {
            _inputController = inputController;
        }
        public void AddScreen(IScreenView screen, IScreenPresenter presenter)
        {
            _views.Add(screen.GetType(),presenter);
        }

        public void ChangeScreen(Type screenType)
        {
            if(_views.TryGetValue(screenType, out var screen))
            {
                _currentScreenPresenter?.DisableInput(_inputController);
                _currentScreenPresenter?.Hide();
                _currentScreenPresenter = screen;
                _currentScreenPresenter.InitializeInput(_inputController);
                _currentScreenPresenter.Show();
            }
        }

        
    }
}