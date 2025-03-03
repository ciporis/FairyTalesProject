using System;
using UnityEngine;
using UnityEngine.UI;

public class ModePanelMover : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Animator _animator;
    [SerializeField] private Button _recordingButton;    

    private bool _isPushed = false;
    private string _pushTrigger = "Push";
    private string _returnTrigger = "Return";

    private void Awake()
    {
        _button.onClick.AddListener(MovePanel);
    }

    private void MovePanel()
    {
        if(_isPushed)
        {
            ReturnPanel();
            return;
        }
        PushPanel();
    }

    private void PushPanel()
    {
        if (FairyTale_Settings.RecordingModeState == true) return;
        _isPushed = true;
        _animator.SetTrigger(_pushTrigger);
        _recordingButton.enabled = false;
    }

    private void ReturnPanel()
    {
        _isPushed = false;
        _animator.SetTrigger(_returnTrigger);
        _recordingButton.enabled = true;
    }
}
