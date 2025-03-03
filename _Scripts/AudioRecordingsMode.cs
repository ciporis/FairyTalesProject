using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioRecordingsMode : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Button _audioModeButton;

    private bool _modeState;

    public event Action<bool> OnAudioRecordingModeStateChanged;

    private void Awake()
    {
        _button.onClick.AddListener(SetAudioRecordingsModeState);
    }

    private void SetAudioRecordingsModeState()
    {
        FairyTale_Settings.AudioRecordingsModeState = FairyTale_Settings.AudioRecordingsModeState == true ? false : true;
        _modeState = FairyTale_Settings.AudioRecordingsModeState;
        if (_modeState == true)
        {
            _audioModeButton.enabled = false;
            OnAudioRecordingModeStateChanged?.Invoke(_modeState);
        }

        else
        {
            _audioModeButton.enabled = true;
            OnAudioRecordingModeStateChanged?.Invoke(_modeState);
        }
    }
}
