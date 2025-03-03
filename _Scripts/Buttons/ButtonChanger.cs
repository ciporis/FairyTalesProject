using UnityEngine;
using UnityEngine.UI;

public class ButtonChanger : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Sprite _defaultImage;
    [SerializeField] private Sprite _imageOnPress;

    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _pressedColor;

    private void Awake()
    {
        _image.sprite = _defaultImage;
        _image.color = _defaultColor;
    }

    public void ChangeColor()
    {
        _image.color = _image.color == _defaultColor ? _pressedColor : _defaultColor;
    }

    public void ChangeSprite()
    {
        _image.sprite = _image.sprite == _defaultImage ? _imageOnPress : _defaultImage;
    }
}
