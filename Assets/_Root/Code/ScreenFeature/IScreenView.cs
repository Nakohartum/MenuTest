using Game.Code.ScreenFeature.ScreenPresenter;
using UnityEngine.InputSystem;

namespace Game.Code.ScreenFeature
{
    public interface IScreenView
    {
        
        IScreenPresenter Presenter { get; }
        void Initialize(IScreenPresenter screenPresenter);
        
    }
}