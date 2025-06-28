using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.ScreenFeature
{
    public class SaveView : MonoBehaviour
    {
        [field: SerializeField] public Image Image { get; private set; }

        public void SetSelected(bool selected)
        {
            Image.color = selected ? Color.red : Color.white;
        }
    }
}