using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.ScreenFeature
{
    public class SettingsScreen : BaseScreenView
    {
        [field: SerializeField] public Button GameSettingsButton { get; private set; }
        [field: SerializeField] public Button ControlsSettingsButton { get; private set; }
        [field: SerializeField] public Button GraphicsSettingsButton { get; private set; }
        [field: SerializeField] public Button AudioSettingsButton { get; private set; }
        [field: SerializeField] public GameSettingsPanel GameSettingsPanel { get; private set; }
        [field: SerializeField] public GraphicsSettingsPanel GraphicsSettingsPanel { get; private set; }
        [field: SerializeField] public AudioSettingsPanel AudioSettingsPanel { get; private set; }
    }
}