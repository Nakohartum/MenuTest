using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.ScreenFeature
{
    public class GraphicsSettingsPanel : MonoBehaviour
    {
        [field: SerializeField] public Button PreviousButton { get; private set; }
        [field: SerializeField] public Button NextButton { get; private set; }
        [field: SerializeField] public TMP_Text Label { get; private set; }

        public void SetLabel(string label)
        {
            Label.text = label;
        }
    }
}