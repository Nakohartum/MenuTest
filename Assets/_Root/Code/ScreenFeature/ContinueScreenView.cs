using UnityEngine;

namespace Game.Code.ScreenFeature
{
    public class ContinueScreenView : BaseScreenView
    {
        [field: SerializeField] public SaveView[] SaveViews { get; set; }   
    }
}