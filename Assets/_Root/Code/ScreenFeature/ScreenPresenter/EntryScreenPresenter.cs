using Game.Code.InputFeature;
using UnityEngine.EventSystems;

namespace Game.Code.ScreenFeature.ScreenPresenter
{
    public class EntryScreenPresenter : IScreenPresenter
    {
        private ScreenPresenter _presenter;
        private UIInputManager _uiInputManager;
        public EntryScreenView View { get; }

        public EntryScreenPresenter(ScreenPresenter presenter, UIInputManager uiInputManager, EntryScreenView view)
        {
            _presenter = presenter;
            View = view;
            _uiInputManager = uiInputManager;
            View.Initialize(this);
            _uiInputManager.Context.OnInputChanged += ChangeHints;
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
        }

        public void Hide()
        {
            View.gameObject.SetActive(false);
        }

        public void OnSubmit()
        {
            _presenter.ChangeScreen(typeof(MainMenuScreen));
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
            inputController.OnSubmit += OnSubmit;
            inputController.OnBack += OnGoBack;
        }

        public void DisableInput(InputController inputController)
        {
            inputController.OnSubmit -= OnSubmit;
            inputController.OnBack -= OnGoBack;
        }
    }
}