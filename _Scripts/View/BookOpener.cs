using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class BookOpener : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private ScrollRect _scrollRect;       
    [SerializeField] private Camera _camera;
    [SerializeField] private Bunny _bunny;

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

        return Mathf.Abs(halfWidth - screenPosition.x) <= 35;
    }

    private void OnMouseUpAsButton()
    {
        if (_scrollRect.velocity.magnitude == 0f && IsInCenter(_screenPosition))
        {       
            BookOpened?.Invoke();
            _bunny.Move();
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
