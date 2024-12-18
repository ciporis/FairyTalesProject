using System;
using UnityEngine;

public class SnapScroller : MonoBehaviour
{
    [SerializeField] private GameObject _bookPrefab;
    [SerializeField] private int _booksCount;
    [SerializeField] private float _spaceBetweenBooks;
    [SerializeField] private RectTransform _contentRectTransform;
    [SerializeField] private float _scrollingSpeed;
    [SerializeField] private string[] _fairyTales;
    
    private Vector3 _contentVector;
    private Vector3[] _booksPositions;
    private GameObject[] _books;
    private int _selectedBookID;

    public bool IsScrolling { get; private set; } 

    private void Awake()
    {
        _books = new GameObject[_booksCount];
        _booksPositions = new Vector3[_booksCount];

        for (int i = 0; i < _booksCount; i++)
        {
            _books[i] = Instantiate(_bookPrefab, transform, false);
            _books[i].GetComponent<Book>().PrefabFairyTaleName = _fairyTales[i];
            if (i == 0) continue;

            RectTransform rectTransform = _books[i].GetComponent<RectTransform>();

            _books[i].transform.localPosition = new Vector3(_books[i - 1].transform.localPosition.x + rectTransform.sizeDelta.x + _spaceBetweenBooks, rectTransform.localPosition.y, rectTransform.localPosition.y);

            _booksPositions[i] = -1 * _books[i].transform.localPosition;
        }
    }

    private void FixedUpdate()
    {
        float closest = float.MaxValue;
        for (int i = 0; i < _booksCount; i++)
        {
            float distance = Mathf.Abs(_contentRectTransform.anchoredPosition.x - _booksPositions[i].x);
            if (distance < closest)
            {
                closest = distance;
                _selectedBookID = i;
            }
        }
        if (IsScrolling) return;
        _contentVector.x = Mathf.SmoothStep(_contentRectTransform.anchoredPosition.x, _booksPositions[_selectedBookID].x, _scrollingSpeed * Time.fixedDeltaTime);
        _contentRectTransform.anchoredPosition = _contentVector;
    }

    public void Scrolling(bool isScrolling)
    {
        IsScrolling = isScrolling;
    }
}