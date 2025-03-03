using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioModeHandler : MonoBehaviour
{
    [SerializeField] private ButtonChanger _buttonChanger;
    [SerializeField] private Button _audioRecordingMode;

    public event Action<bool> AudioModeChanged;

    private void Awake()
    {
        FairyTale_Settings.AudioModeState = false;
    }

    public void HandleClick()
    {
        if (FairyTale_Settings.RecordingModeState == true) return;

        _buttonChanger.ChangeColor();
        SetAudioModeState();
    }

    private void SetAudioModeState()
    {
        FairyTale_Settings.AudioModeState = FairyTale_Settings.AudioModeState == true ? false : true;
        _audioRecordingMode.enabled = !FairyTale_Settings.AudioModeState;
        AudioModeChanged?.Invoke(FairyTale_Settings.AudioModeState);
    }
}
