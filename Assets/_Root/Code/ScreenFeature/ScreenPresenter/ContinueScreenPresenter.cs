using Game.Code.InputFeature;
using Game.Code.ScreenFeature.ScreenPresenter;
using UnityEngine.EventSystems;

namespace Game.Code.ScreenFeature
{
    public class ContinueScreenPresenter : IScreenPresenter
    {
        private ContinueScreenView _view;
        private ScreenPresenter.ScreenPresenter _presenter;
        private UIInputManager _uiInputManager;

        public ContinueScreenPresenter(ContinueScreenView view, ScreenPresenter.ScreenPresenter presenter, UIInputManager uiInputManager)
        {
            _view = view;
            _presenter = presenter;
            _uiInputManager = uiInputManager;
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
            EventSystem.current.SetSelectedGameObject(_view.SaveViews[0].gameObject);
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