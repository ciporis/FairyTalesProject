using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public MainMenuSettings Settings = new MainMenuSettings();
    public bool MusicState;
    private void Awake()
    {
        MusicState = Settings.MusicState;
    } 
}