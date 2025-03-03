using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FairyTaleView : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _buttonNext;
    [SerializeField] private Button _buttonPrevious;
    [SerializeField] private TextMeshProUGUI _slideText;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioModeHandler _audioModeHandler;
    [SerializeField] private RecordingMode _recordingMode;
    [SerializeField] private AudioRecordingsMode _audioRecordingMode;
    [SerializeField] private Record _record;
    [SerializeField] private Image _currentImage;
    [SerializeField] private Image _currentBlur;

    private bool _audioModeState;
    private bool _audioRecordingModeState;

    private int _slideIndex = 0;

    private string _fairyTaleName;
    private string _language;

    private string[] _sentences;
    private Sprite[] _slides;
    private AudioClip[] _audioClips;
    private AudioClip[] _recordings;

    private TextMeshProUGUI _text;

    private Coroutine _waitingForAudioClipCoroutine;

    public event Action<int> SlideIndexChanged;

    private void Awake()
    {
        _buttonNext.onClick.AddListener(NextSlide);
        _buttonPrevious.onClick.AddListener(PreviousSlide);

        _fairyTaleName = BookData.FairyTaleName;
        _language = BookData.Language;

        _slides = ImagesParser.GetSlides(_fairyTaleName);
        Debug.Log("slides");
        _sentences = TextParser.GetParsedText(_fairyTaleName, _language);
        Debug.Log("sentences");
        _audioClips = AudioParser.GetAudioClips($"{_fairyTaleName}/Audio", _language);
        _recordings = AudioParser.GetAudioClips($"{_fairyTaleName}/Recordings", _language);

        _currentImage.sprite = _slides[_slideIndex];
        _currentBlur.sprite = _slides[_slideIndex];
        _slideText.text = _sentences[_slideIndex];
        _audioSource.clip = _audioClips[_slideIndex];
    }

    private void OnEnable()
    {
        _audioModeHandler.AudioModeChanged += SetCurrentAudioModeState;
        _audioRecordingMode.OnAudioRecordingModeStateChanged += SetCurrentAudioRecordingModeState;
        _record.RecordingAdded += GetCurrentRecordings;
    }

    private void OnDisable()
    {
        _audioModeHandler.AudioModeChanged -= SetCurrentAudioModeState; 
        _audioRecordingMode.OnAudioRecordingModeStateChanged -= SetCurrentAudioRecordingModeState;
        _record.RecordingAdded -= GetCurrentRecordings;
    }

    private void GetCurrentRecordings(int newRecordIndex, AudioClip clip)
    {
        _recordings[newRecordIndex] = clip;
    }

    private void SetCurrentAudioRecordingModeState(bool state)
    {
        _audioRecordingModeState = state;
        if (_audioRecordingModeState == true)
        {
            if (_slideIndex >= _recordings.Length) return;
            _audioSource.clip = _recordings[_slideIndex];
            PlayCurrentAudioClip(); 
        }
        else
            StopCurrentClip();
    }

    private void SetCurrentAudioModeState(bool audioModeState)
    {
        _audioModeState = audioModeState;
        if (_audioModeState == true)
        {
            _audioSource.clip = _audioClips[_slideIndex];
            PlayCurrentAudioClip();        
        }
            
        else
            StopCurrentClip();
    }

    private void StopCurrentClip()
    {
        _audioSource.Stop();
        StopCoroutine(_waitingForAudioClipCoroutine);
    }

    private void PlayCurrentAudioClip()
    {
        _waitingForAudioClipCoroutine = StartCoroutine(PlayAudioClipInAudioMode(_audioSource.clip.length));
    }

    private void NextSlide()
    {
        ChangeSlideData(1);
    }
 
    private void PreviousSlide()
    {
        ChangeSlideData(-1);
    }

    private void ChangeSlideData(int currentSlideDirection)
    {
        if((currentSlideDirection > 0 && _slideIndex + currentSlideDirection > _slides.Length - 1) || (currentSlideDirection < 0 && _slideIndex + currentSlideDirection < 0))
            return;

        _slideIndex += currentSlideDirection;

        SlideIndexChanged?.Invoke(_slideIndex);

        _slideText.text = _sentences[_slideIndex];
        _currentImage.sprite = _slides[_slideIndex];
        _currentBlur.sprite = _slides[_slideIndex];

        if (_audioModeState == true)
        {
            _audioSource.clip = _audioClips[_slideIndex];
            _waitingForAudioClipCoroutine = StartCoroutine(PlayAudioClipInAudioMode(_audioSource.clip.length));         
        }
        if(_audioRecordingModeState == true)
        {
            if (_slideIndex >= _recordings.Length) return;
            _audioSource.clip = _recordings[_slideIndex];
            _waitingForAudioClipCoroutine = StartCoroutine(PlayAudioClipInAudioMode(_audioSource.clip.length));
        }
    }

    private IEnumerator PlayAudioClipInAudioMode(float seconds)
    {     
        _audioSource.Play();
        yield return new WaitForSeconds(seconds + 0.4f);
        NextSlide();
    }
}