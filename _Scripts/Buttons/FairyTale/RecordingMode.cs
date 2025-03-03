using System;
using UnityEngine;
using UnityEngine.UI;

public class RecordingMode : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Animator _animator;

    [SerializeField] private Button[] _buttonsForDisable;

    public event Action<bool> OnRecordingModeStateChanged;

    private string _pushTrigger = "Push";
    private string _returnTrigger = "Return";

    private bool _isRecording = false;

    private void Awake()
    {
        FairyTale_Settings.RecordingModeState = false;

        _button.onClick.AddListener(MovePanel);
        _button.onClick.AddListener(SetRecordingModeState);
    }

    private void MovePanel()
    {
        if (FairyTale_Settings.AudioModeState == true) return;
        if (_isRecording)
            ReturnPanel();
        else
            PushPanel();            
    }

    private void PushPanel()
    {
        _animator.SetTrigger(_pushTrigger);
        _isRecording = true;
        SetRecordingModeState();
        FairyTale_Settings.RecordingModeState = true;
        ChangeButtonsState(false);
    }

    private void ChangeButtonsState(bool state)
    {
        for (int i = 0; i < _buttonsForDisable.Length; i++)
        {
            _buttonsForDisable[i].enabled = state;
        }
    }

    private void ReturnPanel()
    {
        _animator.SetTrigger(_returnTrigger);
        _isRecording = false;
        SetRecordingModeState();
        FairyTale_Settings.RecordingModeState = false;
        ChangeButtonsState(true);
    }

    private void SetRecordingModeState()
    {
        OnRecordingModeStateChanged?.Invoke(_isRecording);
    }
}