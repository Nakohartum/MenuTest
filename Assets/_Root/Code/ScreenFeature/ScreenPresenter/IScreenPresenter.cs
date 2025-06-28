using Game.Code.InputFeature;

namespace Game.Code.ScreenFeature.ScreenPresenter
{
    public interface IScreenPresenter
    {

        void ChangeHints(UIType type);

        void Show();

        void Hide();
        void OnSubmit();
        void OnGoBack();
        void OnGoRight();
        void OnGoLeft();
        void InitializeInput(InputController inputController);
        void DisableInput(InputController inputController);
    }
}