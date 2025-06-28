using Game.Code.InputFeature;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Code.ScreenFeature.ScreenPresenter
{
    public class SettingsScreenPresenter : IScreenPresenter
    {
        private ScreenPresenter _presenter;
        private UIInputManager _uiInputManager;
        public SettingsScreen SettingsScreen { get; }
        private SettingsScreenModel _settingsScreenModel;
        private int _currentLanguageSelected;
        private int _currentGameModeSelected;
        private int _currentGraphicsSelected;

        public SettingsScreenPresenter(ScreenPresenter presenter, UIInputManager uiInputManager, SettingsScreen settingsScreen)
        {
            _presenter = presenter;
            SettingsScreen = settingsScreen;
            _uiInputManager = uiInputManager;
            settingsScreen.Initialize(this);
            _uiInputManager.Context.OnInputChanged += ChangeHints;
            _settingsScreenModel = new SettingsScreenModel();
            
            OnGameSettingsButtonClick();
            SettingsScreen.GameSettingsPanel.NextLanguageButton.onClick.AddListener(GetNextLanguage);
            SettingsScreen.GameSettingsPanel.PreviousLanguageButton.onClick.AddListener(GetPreviousLanguage);
            SettingsScreen.GameSettingsPanel.NextLevelButton.onClick.AddListener(GetNextLevel);
            SettingsScreen.GameSettingsPanel.PreviousLevelButton.onClick.AddListener(GetPreviousLevel);
            SettingsScreen.GraphicsSettingsPanel.NextButton.onClick.AddListener(GetNextGraphicsLevel);
            SettingsScreen.GraphicsSettingsPanel.PreviousButton.onClick.AddListener(GetPreviousGraphicsLevel);
            
            DisableAllPanels();
        }

        private void GetPreviousGraphicsLevel()
        {
            _currentGraphicsSelected = _currentGraphicsSelected - 1 >= 0 ? _currentGraphicsSelected - 1 : _settingsScreenModel.GraphicsQuality.Length - 1;
            SettingsScreen.GraphicsSettingsPanel.SetLabel(_settingsScreenModel.LevelModes[_currentGraphicsSelected]);
        }
        
        private void GetNextGraphicsLevel()
        {
            _currentGraphicsSelected = (_currentGraphicsSelected + 1) % _settingsScreenModel.GraphicsQuality.Length;
            SettingsScreen.GraphicsSettingsPanel.SetLabel(_settingsScreenModel.LevelModes[_currentGraphicsSelected]);
        }

        private void GetPreviousLevel()
        {
            _currentGameModeSelected = _currentGameModeSelected - 1 >= 0 ? _currentGameModeSelected - 1 : _settingsScreenModel.LevelModes.Length - 1;
            SettingsScreen.GameSettingsPanel.SetGameMode(_settingsScreenModel.LevelModes[_currentGameModeSelected]);
        }

        private void GetNextLevel()
        {
            _currentGameModeSelected = (_currentGameModeSelected + 1) % _settingsScreenModel.LevelModes.Length;
            SettingsScreen.GameSettingsPanel.SetGameMode(_settingsScreenModel.LevelModes[_currentGameModeSelected]);
        }

        private void GetPreviousLanguage()
        {
            _currentLanguageSelected = _currentLanguageSelected - 1 >= 0 ? _currentLanguageSelected - 1 : _settingsScreenModel.GameLanguages.Length - 1;
            SettingsScreen.GameSettingsPanel.SetLanguage(_settingsScreenModel.GameLanguages[_currentLanguageSelected]);
        }

        private void GetNextLanguage()
        {
            _currentLanguageSelected = (_currentLanguageSelected + 1) % _settingsScreenModel.GameLanguages.Length;
            SettingsScreen.GameSettingsPanel.SetLanguage(_settingsScreenModel.GameLanguages[_currentLanguageSelected]);
        }

        public void ChangeHints(UIType type)
        {
            SettingsScreen.PcHint.SetActive(type == UIType.PC);
            SettingsScreen.XboxHint.SetActive(type == UIType.Xbox);
            SettingsScreen.PsHint.SetActive(type == UIType.PS);
        }

        public void Show()
        {
            SettingsScreen.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(SettingsScreen.GameSettingsButton.gameObject);
        }

        public void Hide()
        {
            SettingsScreen.gameObject.SetActive(false);
        }

        public void OnSubmit()
        {
        }

        public void OnGoBack()
        {
            _presenter.ChangeScreen(typeof(MainMenuScreen));
        }

        public void OnGoRight()
        {
            if (EventSystem.current.currentSelectedGameObject == SettingsScreen.AudioSettingsPanel.VolumeSlider.gameObject)
            {
                SettingsScreen.AudioSettingsPanel.SetVolume(SettingsScreen.AudioSettingsPanel.VolumeSlider.value + 0.1f);
            }
        }

        public void OnGoLeft()
        {
            if (EventSystem.current.currentSelectedGameObject == SettingsScreen.AudioSettingsPanel.VolumeSlider.gameObject)
            {
                SettingsScreen.AudioSettingsPanel.SetVolume(SettingsScreen.AudioSettingsPanel.VolumeSlider.value - 0.1f);
            }
        }

        public void InitializeInput(InputController inputController)
        {
            SettingsScreen.GameSettingsButton.onClick.AddListener(OnGameSettingsButtonClick);
            SettingsScreen.AudioSettingsButton.onClick.AddListener(AudioSettingsButtonClick);
            SettingsScreen.GraphicsSettingsButton.onClick.AddListener(GraphicsSettingsButtonClick);
            inputController.OnNavigateButtonsClick += NavigateButtonsClicked;
            inputController.OnBack += OnGoBack;
        }

        private void NavigateButtonsClicked(Vector2 obj)
        {
            Debug.Log(obj);
            if (obj.x < 0)
            {
                OnGoLeft();
            }
            else
            {
                OnGoRight();
            }
        }

        private void GraphicsSettingsButtonClick()
        {
            DisableAllPanels();
            SettingsScreen.GraphicsSettingsPanel.gameObject.SetActive(true);
        }

        private void AudioSettingsButtonClick()
        {
            DisableAllPanels();
            SettingsScreen.AudioSettingsPanel.gameObject.SetActive(true);
        }

        private void OnGameSettingsButtonClick()
        {
            DisableAllPanels();
            SettingsScreen.GameSettingsPanel.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(SettingsScreen.GameSettingsPanel.PreviousLevelButton.gameObject);
            SettingsScreen.GameSettingsPanel.SetLanguage(_settingsScreenModel.GameLanguages[0]);
            SettingsScreen.GameSettingsPanel.SetGameMode(_settingsScreenModel.LevelModes[0]);
        }

        public void DisableInput(InputController inputController)
        {
            SettingsScreen.GameSettingsButton.onClick.RemoveListener(OnGameSettingsButtonClick);
            SettingsScreen.AudioSettingsButton.onClick.RemoveListener(AudioSettingsButtonClick);
            SettingsScreen.GraphicsSettingsButton.onClick.RemoveListener(GraphicsSettingsButtonClick);
            inputController.OnNavigateButtonsClick -= NavigateButtonsClicked;
            inputController.OnBack -= OnGoBack;
        }

        private void DisableAllPanels()
        {
            SettingsScreen.GameSettingsPanel.gameObject.SetActive(false);
            SettingsScreen.GraphicsSettingsPanel.gameObject.SetActive(false);
            SettingsScreen.AudioSettingsPanel.gameObject.SetActive(false);
        }
    }
}