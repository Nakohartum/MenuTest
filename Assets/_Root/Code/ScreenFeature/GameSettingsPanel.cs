using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.ScreenFeature
{
    public class GameSettingsPanel : MonoBehaviour
    {
        [field: SerializeField] public Button NextLevelButton { get; private set; }
        [field: SerializeField] public Button NextLanguageButton { get; private set; }
        [field: SerializeField] public Button PreviousLevelButton { get; private set; }
        [field: SerializeField] public Button PreviousLanguageButton { get; private set; }
        [field: SerializeField] public TMP_Text LanguageLabel { get; private set; }
        [field: SerializeField] public TMP_Text GameModeLabel { get; private set; }

        public void SetLanguage(string language)
        {
            LanguageLabel.text = language;
        }

        public void SetGameMode(string gameMode)
        {
            GameModeLabel.text = gameMode;
        }
    }
}