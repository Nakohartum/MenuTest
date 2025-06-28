namespace Game.Code.ScreenFeature
{
    public class SettingsScreenModel
    {
        public string[] LevelModes = {"Easy", "Medium", "Hard"};
        public string[] GameLanguages = {"English", "Russian"};
        public string[] GraphicsQuality = {"Low", "Medium", "High"};

        public string GetLevelMode(int index)
        {
            return LevelModes[index];
        }

        public string GetLanguage(int index)
        {
            return GameLanguages[index];
        }
        
        public string GetGraphics(int index)
        {
            return GraphicsQuality[index];
        }
    }
}