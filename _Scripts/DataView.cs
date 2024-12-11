using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataView : MonoBehaviour
{
    [SerializeField] private BookManager _bookManager;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _buttonNext;
    [SerializeField] private Button _buttonPrevious;
    [SerializeField] private TextMeshProUGUI _slideText;

    private Image _currentImage;
    private int _slideIndex;
    private int _sentenceIndex;

    private void Start()
    {
        _buttonNext.onClick.AddListener(NextSlide);
        _buttonPrevious.onClick.AddListener(PreviousSlide);
        _currentImage = _canvas.GetComponent<Image>();
        _currentImage.sprite = _bookManager.Slides[_slideIndex];
        _slideText.text = _bookManager.Sentences[_sentenceIndex];
    }

    private void NextSlide()
    {
        if (_slideIndex == _bookManager.Slides.Length - 1 || _sentenceIndex == _bookManager.Sentences.Length - 1)
        {
            return;
        }
        _slideIndex++;
        _sentenceIndex++;
        _slideText.text = _bookManager.Sentences[_sentenceIndex];
        _currentImage.sprite = _bookManager.Slides[_slideIndex];
    }
 
    private void PreviousSlide()
    {
        if (_slideIndex == 0 || _sentenceIndex == 0)
        {
            return;
        }
        _slideIndex--;
        _sentenceIndex--;
        _slideText.text = _bookManager.Sentences[_sentenceIndex];
        _currentImage.sprite = _bookManager.Slides[_slideIndex];
    }
}
