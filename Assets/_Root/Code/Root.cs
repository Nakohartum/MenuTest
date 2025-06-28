using System;
using Game.Code.InputFeature;
using Game.Code.ScreenFeature;
using Game.Code.ScreenFeature.ScreenPresenter;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Code.Root
{

    public class Root : MonoBehaviour
    {
        
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private EntryScreenView _entryScreen;
        [SerializeField] private MainMenuScreen _mainMenuScreen;
        [SerializeField] private ContinueScreenView _continueScreen;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private CreditsScreen _creditsScreen;
        private InputController _inputController;
        private UIInputManager _uiInputManager;

        private void Start()
        {
            _uiInputManager = new UIInputManager(_playerInput);
            
            _inputController = new InputController(_playerInput);
            var screenPresenter = new ScreenPresenter(_inputController);
            CreateEntryScreenPresenter(screenPresenter, _uiInputManager);
            CreateMainMenuScreenPresenter(screenPresenter, _uiInputManager);
            CreateContinueScreenPresenter(screenPresenter, _uiInputManager);
            CreateSettingsScreenPresenter(screenPresenter, _uiInputManager);
            CreateCreditsScreenPresenter(screenPresenter, _uiInputManager);
            screenPresenter.ChangeScreen(typeof(EntryScreenView));
            _uiInputManager.ApplyCurrentStrategy();
        }

        private void CreateCreditsScreenPresenter(ScreenPresenter screenPresenter, UIInputManager uiInputManager)
        {
            var creditsScreenPresenter = new CreditsScreenPresenter(_creditsScreen, uiInputManager, screenPresenter);
            screenPresenter.AddScreen(_creditsScreen, creditsScreenPresenter);
        }

        private void CreateContinueScreenPresenter(ScreenPresenter screenPresenter, UIInputManager uiInputManager)
        {
            var continueScreenPresenter = new ContinueScreenPresenter(_continueScreen, screenPresenter, uiInputManager);
            screenPresenter.AddScreen(_continueScreen, continueScreenPresenter);
        }

        private void CreateSettingsScreenPresenter(ScreenPresenter screenPresenter, UIInputManager uiInputManager)
        {
            var settingsScreenPresenter = new SettingsScreenPresenter(screenPresenter, uiInputManager, _settingsScreen);
            screenPresenter.AddScreen(_settingsScreen, settingsScreenPresenter);
        }

        private void CreateMainMenuScreenPresenter(ScreenPresenter screenPresenter, UIInputManager uiInputManager)
        {
            var mainMenuScreenPresenter = new MainMenuScreenPresenter(screenPresenter, uiInputManager, _mainMenuScreen);
            screenPresenter.AddScreen(_mainMenuScreen, mainMenuScreenPresenter);
        }

        private void CreateEntryScreenPresenter(ScreenPresenter screenPresenter, UIInputManager uiInputManager)
        {
            var entryScreenPresenter = new EntryScreenPresenter(screenPresenter, uiInputManager, _entryScreen);
            screenPresenter.AddScreen(_entryScreen, entryScreenPresenter);
        }
    }
}