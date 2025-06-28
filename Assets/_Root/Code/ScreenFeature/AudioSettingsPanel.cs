using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.ScreenFeature
{
    public class AudioSettingsPanel : MonoBehaviour
    {
        [field: SerializeField] public Slider VolumeSlider { get; private set; }
        [field: SerializeField] public TMP_Text Value { get; private set; }

        public void SetVolume(float volume)
        {
            VolumeSlider.value = volume;
            Value.text = volume.ToString("0.0");
        }
    }
}