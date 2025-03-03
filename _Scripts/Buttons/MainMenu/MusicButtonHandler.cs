using UnityEngine;

public class MusicButtonHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private ButtonChanger _colorSetter;

    public void HandleClick()
    {
        _colorSetter.ChangeColor();
        if (_music.mute == false)   
            TurnOffMusic();
        else
            TurnOnMusic();
    }

    private void TurnOnMusic()
    {
        _music.mute = false;
    }

    private void TurnOffMusic()
    {
        _music.mute = true;
    }

}
