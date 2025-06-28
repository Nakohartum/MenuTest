using System;
using Game.Code.Root;
using Game.Code.ScreenFeature.ScreenPresenter;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Code.ScreenFeature
{
    public class MainMenuScreen : BaseScreenView
    {
        [field: SerializeField] public Button StartGameButton {get; private set;} 
        [field: SerializeField] public Button ContinueGameButton {get; private set;} 
        [field: SerializeField] public Button SettingsButton {get; private set;} 
        [field: SerializeField] public Button CreditsButton {get; private set;}
        [field: SerializeField] public Button QuitButton {get; private set;}
    }
}