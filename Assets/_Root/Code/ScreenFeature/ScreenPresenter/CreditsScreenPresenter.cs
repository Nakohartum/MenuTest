using Game.Code.InputFeature;
using Game.Code.ScreenFeature.ScreenPresenter;

namespace Game.Code.ScreenFeature
{
    public class CreditsScreenPresenter : IScreenPresenter
    {
        private CreditsScreen _view;
        private UIInputManager _uiInputManager;
        private ScreenPresenter.ScreenPresenter _presenter;

        public CreditsScreenPresenter(CreditsScreen view, UIInputManager uiInputManager, ScreenPresenter.ScreenPresenter presenter)
        {
            _view = view;
            _uiInputManager = uiInputManager;
            _presenter = presenter;
            _uiInputManager.Context.OnInputChanged += ChangeHints;
        }
        
        public void ChangeHints(UIType type)
        {
            _view.PcHint.SetActive(type == UIType.PC);
            _view.XboxHint.SetActive(type == UIType.Xbox);
            _view.PsHint.SetActive(type == UIType.PS);
        }

        public void Show()
        {
            _view.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _view.gameObject.SetActive(false);
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
        }

        public void OnGoLeft()
        {
        }

        public void InitializeInput(InputController inputController)
        {
            inputController.OnBack += OnGoBack;
        }

        public void DisableInput(InputController inputController)
        {
            inputController.OnBack -= OnGoBack;
        }
    }
}