using System;
using UnityEngine;
using UnityEngine.UI;

public class SnapScroller : MonoBehaviour
{
    [SerializeField] private int _booksCount;
    [SerializeField] private float _spaceBetweenBooks;
    [SerializeField] private RectTransform _contentRectTransform;
    [SerializeField] private float _scrollingSpeed;

    [SerializeField] private GameObject[] _books;

    private Vector3 _contentVector;
    private Vector3[] _booksPositions;

    private int _selectedBookID;

    public bool IsScrolling { get; private set; } 

    private void Awake()
    {
        _booksPositions = new Vector3[_booksCount];

        for (int i = 0; i < _booksCount; i++)
        {
            if (i == 0) continue;

            RectTransform rectTransform = _books[i].GetComponent<RectTransform>();

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