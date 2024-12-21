using System;
using UnityEngine;
using UnityEngine.UI;

public class FairyTale_AudioModeHandler : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _pressedColor;

    public event Action<bool> AudioModeChanged;

    public void HandleClick()
    {
        ChangeColor();
        SetAudioModeState();
    }

    private void Awake()
    {
        _image.color = _defaultColor;
    }

    private void ChangeColor()
    {
        if(_image.color == _pressedColor)
            _image.color = _defaultColor;
        else
            _image.color = _pressedColor;
    }

    private void SetAudioModeState()
    {
        FairyTale_Settings.AudioModeState = FairyTale_Settings.AudioModeState == true ? false : true;
        AudioModeChanged?.Invoke(FairyTale_Settings.AudioModeState);
    }
}
