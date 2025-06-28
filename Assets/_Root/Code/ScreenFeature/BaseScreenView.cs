using Game.Code.ScreenFeature.ScreenPresenter;
using UnityEngine;

namespace Game.Code.ScreenFeature
{
    public abstract class BaseScreenView : MonoBehaviour, IScreenView
    {
        [field: SerializeField] public GameObject PcHint {get; private set;}
        [field: SerializeField] public GameObject XboxHint {get; private set;}
        [field: SerializeField] public GameObject PsHint {get; private set;}

        public IScreenPresenter Presenter { get; private set; }


        public virtual void Initialize(IScreenPresenter screenPresenter)
        {
            Presenter = screenPresenter;
        }
    }
}