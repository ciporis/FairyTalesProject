using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class BookView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _openZone;
    [SerializeField] private RectTransform _openZoneCords;
    [SerializeField] private SnapScroller _scroller;
    [SerializeField] private RectTransform _rectTransform;

    private string _openTrigger = "Open";
    private bool _isReadyToOpen = false;

    private string _loadingSceneName = "FairyTale";

    private float _distanceToBound;
    private float _rightBoundX;
    private float _leftBoundX;

    public event Action BookOpened;

    private void Awake()    
    {
        _distanceToBound = _openZoneCords.localScale.x / 2f;
        _rightBoundX = _openZoneCords.position.x + _distanceToBound * 10f;
        _leftBoundX = _openZoneCords.position.x - _distanceToBound * 10f;
    }

    private void Update()
    {
        if (_rectTransform.position.x >= _leftBoundX && _rectTransform.position.x <= _rightBoundX)
        {
            _isReadyToOpen = true;
        }
        else
            _isReadyToOpen = false;
    }

    private void OnMouseUpAsButton()
    {
        if (!_scroller.IsScrolling && _isReadyToOpen)
        {
            Debug.Log("Sosal?");
            _scroller.enabled = false;
            BookOpened?.Invoke();

            StartCoroutine(OpenBook());
        }
    }

    private IEnumerator OpenBook()
    {
        _animator.SetTrigger(_openTrigger);
        //float animationLength = _animator.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(2.35f);
        SceneManager.LoadScene(_loadingSceneName);
        _isReadyToOpen = false;
    }
}
