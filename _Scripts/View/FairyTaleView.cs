using System;
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
    [SerializeField] private FairyTale_AudioModeHandler _audioModeHandler;

    private bool _audioModeState;

    private Image _currentImage;
    private int _slideIndex;
    private int _sentenceIndex;
    private int _audioIndex;

    private string _fairyTaleName;

    private string[] _sentences;
    private Sprite[] _slides;
    private AudioClip[] _audioClips;


    private void OnEnable()
    {
        _audioModeHandler.AudioModeChanged += SetCurrentAudioModeState;
    }

    private void OnDisable()
    {
        _audioModeHandler.AudioModeChanged -= SetCurrentAudioModeState;
    }

    private void SetCurrentAudioModeState(bool audioModeState)
    {
        _audioModeState = audioModeState;
        if (_audioModeState == true)
            PlayCurrentAudioClip();
        else
            StopCurrentClip();
    }

    private void StopCurrentClip()
    {
        _audioSource.Stop();
    }

    private void PlayCurrentAudioClip()
    {
        _audioSource.clip = _audioClips[_audioIndex];
        _audioSource.Play();
    }

    private void Awake()
    {
        _buttonNext.onClick.AddListener(NextSlide);
        _buttonPrevious.onClick.AddListener(PreviousSlide);
        _currentImage = _canvas.GetComponent<Image>();

        _fairyTaleName = BookData.FairyTaleName;

        _sentences = TextParser.GetParsedText(_fairyTaleName);
        _slides = ImagesParser.GetSlides(_fairyTaleName);
        _audioClips = AudioParser.GetAudioClips(_fairyTaleName);

        _currentImage.sprite = _slides[_slideIndex];
        _slideText.text = _sentences[_sentenceIndex];
        _audioSource.clip = _audioClips[_audioIndex];
    }

    private void NextSlide()
    {
        if (_slideIndex == _slides.Length - 1 || _sentenceIndex == _sentences.Length - 1 || _audioIndex == _audioClips.Length - 1)
            return;

        _slideIndex++;
        _sentenceIndex++;
        _audioIndex++;
        _slideText.text = _sentences[_sentenceIndex];
        _currentImage.sprite = _slides[_slideIndex];

        if(_audioModeState == true)
        {
            _audioSource.clip = _audioClips[_audioIndex];
            _audioSource.Play();
        }
    }
 
    private void PreviousSlide()
    {
        if (_slideIndex == 0 || _sentenceIndex == 0 || _audioIndex == 0)
            return;

        _slideIndex--;
        _sentenceIndex--;
        _audioIndex--;
        _slideText.text = _sentences[_sentenceIndex];
        _currentImage.sprite = _slides[_slideIndex];

        if (_audioModeState == true)
        {
            _audioSource.clip = _audioClips[_audioIndex];
            _audioSource.Play();
        }
    }
}
