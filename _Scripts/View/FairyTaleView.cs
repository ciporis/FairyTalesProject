using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FairyTaleView : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _buttonNext;
    [SerializeField] private Button _buttonPrevious;
    [SerializeField] private TextMeshProUGUI _slideText;

    private Image _currentImage;
    private int _slideIndex;
    private int _sentenceIndex;

    private string _fairyTaleName;

    private string[] _sentences;
    private Sprite[] _slides;
    private void Awake()
    {
        _buttonNext.onClick.AddListener(NextSlide);
        _buttonPrevious.onClick.AddListener(PreviousSlide);
        _currentImage = _canvas.GetComponent<Image>();

        _fairyTaleName = BookData.FairyTaleName;

        _sentences = TextParser.GetParsedText(_fairyTaleName);
        _slides = ImagesParser.GetSlides(_fairyTaleName);

        _currentImage.sprite = _slides[_slideIndex];
        _slideText.text = _sentences[_sentenceIndex];
    }

    private void NextSlide()
    {
        if (_slideIndex == _slides.Length - 1 || _sentenceIndex == _sentences.Length - 1)
            return;

        _slideIndex++;
        _sentenceIndex++;
        _slideText.text = _sentences[_sentenceIndex];
        _currentImage.sprite = _slides[_slideIndex];
    }
 
    private void PreviousSlide()
    {
        if (_slideIndex == 0 || _sentenceIndex == 0)
            return;

        _slideIndex--;
        _sentenceIndex--;
        _slideText.text = _sentences[_sentenceIndex];
        _currentImage.sprite = _slides[_slideIndex];
    }
}
