using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    [SerializeField] private Button _startStopRecordButton;
    [SerializeField] private Button _listenRecordButton;
    [SerializeField] private Button _saveRecordButton;

    [SerializeField] private FairyTaleView _fairyTaleView;
    [SerializeField] private AudioSource _audioSource;

    private AudioClip _recordedClip;

    private int _slideIndex = 0;

    private string _deviceName;
    private bool _isRecording = false;
    private bool _isPlaying = false;

    private float _recordedClipLength;
    private float _recordingStartTime;

    private string _fairyTaleName;
    private string _language;

    private Coroutine _coroutine;

    public event Action<int, AudioClip> RecordingAdded;

    private void Awake()
    {
        _deviceName = Microphone.devices[0];
        _fairyTaleName = BookData.FairyTaleName;
        _language = BookData.Language;

        _startStopRecordButton.onClick.AddListener(StartStopRecord);
        _listenRecordButton.onClick.AddListener(ListenRecord);
        _saveRecordButton.onClick.AddListener(SaveRecord);
    }

    private void OnEnable()
    {
        _fairyTaleView.SlideIndexChanged += SetSlideIndex;
    }

    private void OnDisable()
    {
        _fairyTaleView.SlideIndexChanged -= SetSlideIndex;
    }

    private void SetSlideIndex(int slideIndex)
    {
        _slideIndex = slideIndex;
    }

    private void StartStopRecord()
    {
        if (_isRecording)
        {
            StopRecording();
        }
        else
        {
            StartRecording();
        }
    }

    private void StartRecording()
    {
        _recordedClip = Microphone.Start(_deviceName, false, 300, 44100);
        _isRecording = true;
        _recordingStartTime = Time.time;
    }

    private void StopRecording()
    {
        Microphone.End(_deviceName);
        _isRecording = false;
        _recordedClipLength = Time.time - _recordingStartTime;
    }

    private void ListenRecord()
    {
        if(_isPlaying)
        {
            _audioSource.Stop();
            _isPlaying = false;
            StopCoroutine(_coroutine);
            return;
        }

        if(!_isRecording && _recordedClip != null)
        {
            _audioSource.clip = _recordedClip;
            _isPlaying = true;
            _coroutine = StartCoroutine(WaitForClipEnd());
        }
    }

    private IEnumerator WaitForClipEnd()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_recordedClipLength + 0.4f);
        _listenRecordButton.GetComponent<ButtonChanger>().ChangeSprite();
        _isPlaying = false;
    }

    private void SaveRecord()
    {
        if (_recordedClip != null)
        {
            string filePath = Application.dataPath + $"/Resources/Content/{_language}/Sounds/FairyTalesAudio/{_fairyTaleName}/Recordings/{_slideIndex}.wav";
            
            SaveWav.FromAudioClip(_recordedClip, filePath, true);

            RecordingAdded?.Invoke(_slideIndex, _recordedClip);
        }
    }
}