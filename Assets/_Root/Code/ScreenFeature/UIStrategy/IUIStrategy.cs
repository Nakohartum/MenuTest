namespace Game.Code.ScreenFeature
{
    public interface IUIStrategy
    {
        UIType GetUIType();
    }

    public enum UIType
    {
        PC,
        Xbox,
        PS
    }

    public class PCStrategy : IUIStrategy
    {
        public UIType GetUIType()
        {
            return UIType.PC;
        }
    }
    
    public class XboxStrategy : IUIStrategy
    {
        public UIType GetUIType()
        {
            return UIType.Xbox;
        }
    }
    
    public class PSStrategy : IUIStrategy
    {
        public UIType GetUIType()
        {
            return UIType.PS;
        }
    }
}