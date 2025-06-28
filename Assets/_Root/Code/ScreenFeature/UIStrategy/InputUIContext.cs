using System;

namespace Game.Code.ScreenFeature
{
    public class InputUIContext
    {
        private IUIStrategy _strategy;
        public event Action<UIType> OnInputChanged = delegate { };

        public void SetStrategy(IUIStrategy strategy)
        {
            if (_strategy?.GetUIType() == strategy.GetUIType())
            {
                return;
            }
            _strategy = strategy;
            OnInputChanged?.Invoke(_strategy.GetUIType());
        }
    }
}