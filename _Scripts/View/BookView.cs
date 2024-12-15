using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class BookView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _openZone;
    [SerializeField] private Transform _openZoneCords;
    [SerializeField] private PageSwiper _pageSwiper;

    private string _openTrigger = "Open";
    private bool _isReadyToOpen = false;

    private string _loadingSceneName = "FairyTale";

    private float _distanceToBound;
    private float _rightBoundX;
    private float _leftBoundX;

    public event Action BookOpened;

    private void Awake()
    {
        _distanceToBound = _openZone.bounds.size.x / 2;
        _rightBoundX = _openZoneCords.position.x + _distanceToBound;
        _leftBoundX = _openZoneCords.position.x - _distanceToBound;
    }

    private void Update()
    {
        if (transform.position.x >= _leftBoundX && transform.position.x <= _rightBoundX)
        {
            _isReadyToOpen = true;
        }
        else
            _isReadyToOpen = false;
    }

    private void OnMouseUpAsButton()
    {
        if (_isReadyToOpen)
        {
            _pageSwiper.enabled = false;
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
