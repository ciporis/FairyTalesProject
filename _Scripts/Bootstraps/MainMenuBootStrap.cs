using UnityEngine;

public class MainMenuBootStrap : MonoBehaviour, IEntryPoint
{
    public void Awake()
    {
        MainMenuSettings settings = new MainMenuSettings();
        settings.MusicState = true;
    }
}
