using Game.Code.InputFeature;
using UnityEngine.EventSystems;

namespace Game.Code.ScreenFeature.ScreenPresenter
{
    public class MainMenuScreenPresenter : IScreenPresenter
    {
        public MainMenuScreen View { get; }
        private ScreenPresenter _presenter;
        private UIInputManager _uiInputManager;
        public MainMenuScreenPresenter(ScreenPresenter presenter, UIInputManager uiInputManager, MainMenuScreen view)
        {
            _presenter = presenter;
            View = view;
            _uiInputManager = uiInputManager;
            _uiInputManager.Context.OnInputChanged += ChangeHints;
            
        }

        private void CreditsClicked()
        {
            _presenter.ChangeScreen(typeof(CreditsScreen));
        }

        private void SettingsClicked()
        {
            _presenter.ChangeScreen(typeof(SettingsScreen));
        }
        
        private void ContinueGameClicked()
        {
            _presenter.ChangeScreen(typeof(ContinueScreenView));   
        }

        public void ChangeHints(UIType type)
        {
            View.PcHint.SetActive(type == UIType.PC);
            View.XboxHint.SetActive(type == UIType.Xbox);
            View.PsHint.SetActive(type == UIType.PS);
        }

        public void Show()
        {
            View.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(View.StartGameButton.gameObject);
        }

        public void Hide()
        {
            View.gameObject.SetActive(false);
        }

        public void OnSubmit()
        {
            
        }

        public void OnGoBack()
        {
        }

        public void OnGoRight()
        {
        }

        public void OnGoLeft()
        {
        }

        public void InitializeInput(InputController inputController)
        {
            View.ContinueGameButton.onClick.AddListener(ContinueGameClicked);
            View.SettingsButton.onClick.AddListener(SettingsClicked);
            View.CreditsButton.onClick.AddListener(CreditsClicked);
            View.QuitButton.onClick.AddListener(Quit);
        }

        private void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); 
#endif
        }


        public void DisableInput(InputController inputController)
        {
            View.ContinueGameButton.onClick.RemoveListener(ContinueGameClicked);
            View.SettingsButton.onClick.RemoveListener(SettingsClicked);
            View.CreditsButton.onClick.RemoveListener(CreditsClicked);
            View.QuitButton.onClick.RemoveListener(Quit);
        }
    }
}