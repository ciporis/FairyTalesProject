using UnityEngine;
using UnityEngine.UI;

public class MusicButtonHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _pressedColor;

    [SerializeField] private Image _image;

    public void HandleClick()
    {
        ChangeColor();
        if (_music.mute == false)   
            TurnOffMusic();
        else
            TurnOnMusic();
    }

    private void ChangeColor()
    {
        if (_image.color == _pressedColor)
            _image.color = _defaultColor;
        else
            _image.color = _pressedColor;
    }

    private void Awake()
    {
        _image.color = _defaultColor;
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
