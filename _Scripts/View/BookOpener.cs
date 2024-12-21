using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class BookOpener : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _openZone;
    [SerializeField] private RectTransform _openZoneCords;
    [SerializeField] private SnapScroller _scroller;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private RectTransform _contentTransform;
    [SerializeField] private ScrollRect _scrollRect;

    [SerializeField] private Camera _camera;

    private string _openTrigger = "Open";
    private string _loadingSceneName = "FairyTale";
    private Vector3 _screenPosition;

    public event Action BookOpened;

    private void FixedUpdate()
    {
        _screenPosition = _camera.WorldToScreenPoint(transform.position);
    }

    private bool IsInCenter(Vector3 screenPosition)
    {
        float halfWidth = Screen.width / 2f;
        float halfHeight = Screen.height / 2f;

        return Mathf.Abs(halfWidth - screenPosition.x) <= 35;
    }

    private void OnMouseUpAsButton()
    {
        if (_scrollRect.velocity.magnitude == 0f && IsInCenter(_screenPosition))
        {       
            BookOpened?.Invoke();
            StartCoroutine(OpenBook());
        }
    }

    private IEnumerator OpenBook()
    {
        _scrollRect.horizontal = false;
        _animator.SetTrigger(_openTrigger);
        yield return new WaitForSeconds(2.3f);     
        SceneManager.LoadScene(_loadingSceneName);
    }   
}
