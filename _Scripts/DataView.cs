using UnityEngine;
using UnityEngine.UI;

public class DataView : MonoBehaviour
{
    [SerializeField] private BookManager _bookManager;
    [SerializeField] private Canvas _canvas;

    private Image _currentImage;
    private int _slideIndex;

    private void Start()
    {
        _currentImage = _canvas.GetComponent<Image>();
        _currentImage.sprite = _bookManager.Slides[_slideIndex];
    }

    private void NextSlide()
    {
        if (_slideIndex == _bookManager.Slides.Length - 1)
        {
            return;
        }

        _slideIndex++;
        _currentImage.sprite = _bookManager.Slides[_slideIndex];
    }

    private void PreviousSlide()
    {
        if (_slideIndex == 0)
        {
            return;
        }
        _slideIndex--;   
        _currentImage.sprite = _bookManager.Slides[_slideIndex];
    }
}
