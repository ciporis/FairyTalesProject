using UnityEngine;

[CreateAssetMenu(menuName = "Configs/MainMenuSettings", fileName = "MainMenuSettings")]
public class MainMenuSettings : ScriptableObject
{
    [field: SerializeField] public bool MusicState;
    [field: SerializeField] public float MusicVolume;
}
